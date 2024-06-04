using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Clients;
using MasterCRM.Application.Services.Orders.History;
using MasterCRM.Application.Services.Orders.Products.Requests;
using MasterCRM.Application.Services.Orders.Requests;
using MasterCRM.Application.Services.Orders.Responses;
using MasterCRM.Application.Services.Orders.Stages;
using MasterCRM.Application.Services.Products;
using MasterCRM.Application.Services.Websites;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;
using MasterCRM.Domain.Exceptions;
using MasterCRM.Domain.Services.Notifications;

namespace MasterCRM.Application.Services.Orders;

public class OrderService(
    INotificationService notificationService,
    IOrderRepository orderRepository, 
    IClientRepository clientRepository,
    IStageRepository stageRepository,
    IProductRepository productRepository,
    IOrderHistoryService historyService,
    IWebsiteRepository websiteRepository) : IOrderService
{
    public async Task<GetOrdersResponse> GetAllByMasterAsync(string masterId, short? tab = null)
    {
        IEnumerable<Order> orders;

        if (tab == null)
            orders = await orderRepository.GetAllByMasterAsync(masterId);
        else
            orders = await orderRepository.GetWithStageByMasterAsync(masterId, (short)tab);

        var ordersArray = orders.ToArray();
        return new GetOrdersResponse(ordersArray.Length, ordersArray.Select(order => order.ToItemResponse()));
    }

    public async Task<OrderDto?> GetOrderByIdAsync(string masterId, Guid orderId)
    {
        var order = await orderRepository.GetByIdAsync(orderId);

        if (order == null)
            return null;
        
        if (order.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the order");
        
        return order.ToDto();
    }

    public async Task<OrderDto> CreateOrderAsync(string masterId, CreateOrderRequest request)
    {
        var stage = await stageRepository.GetWithTabByMaster(masterId, request.StageTab)
            ?? throw new NotFoundException($"Stage with tab \"{request.StageTab}\" not found");

        var products = await GetProductsForOrderAsync(masterId, request.Products);
        
        var newOrder = new Order
        {
            Id = Guid.NewGuid(),
            MasterId = masterId,
            Name = Client.GetInitials(request.Client.FullName),
            Address = request.Address,
            StageId = stage.Id,
            TotalAmount = request.TotalAmount,
            IsCalculationAutomated = request.IsCalculationAutomated,
            Comment = request.Comment,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            OrderProducts = products
        };
        
        await orderRepository.CreateAsync(newOrder);
        
        var client = await CreateOrSetClientAsync(newOrder, request.Client.FullName, request.Client.Email, request.Client.Phone);
        
        await historyService.AddNewOrderHistoryAsync(newOrder.Id, newOrder.Name, newOrder.CreatedAt);
        
        await orderRepository.SaveChangesAsync();
        var order = await orderRepository.GetByIdAsync(newOrder.Id);
        
        await notificationService.NotifyClientOrderCreated(order!, client);
        
        return newOrder.ToDto();
    }

    public async Task CreateOrderForWebsiteAsync(string websiteAddress, CreateWebsiteOrderRequest request)
    {
        var masterId = await websiteRepository.GetOwnerIdAsync(websiteAddress)
            ?? throw new NotFoundException("Website not found");
        
        var stage = await stageRepository.GetStartByMasterAsync(masterId)
            ?? throw new NotFoundException("Start stage not found");
        
        var products = await GetProductsForOrderAsync(masterId, request.Products);
        var totalAmount = products.Sum(p => p.UnitPrice * p.Quantity);
        
        var newOrder = new Order
        {
            Id = Guid.NewGuid(),
            MasterId = masterId,
            Name = Client.GetInitials(request.Client.FullName),
            Address = request.Address,
            StageId = stage.Id,
            TotalAmount = totalAmount,
            IsCalculationAutomated = true,
            Comment = request.Comment,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            OrderProducts = products
        };
        
        await orderRepository.CreateAsync(newOrder);
        
        var client = await CreateOrSetClientAsync(newOrder, request.Client.FullName, request.Client.Email, request.Client.Phone);
        
        await historyService.AddNewOrderHistoryAsync(newOrder.Id, newOrder.Name, newOrder.CreatedAt);
        
        await orderRepository.SaveChangesAsync();
        var order = await orderRepository.GetByIdAsync(newOrder.Id);

        await notificationService.NotifyMasterOrderCreated(order!, client);
        await notificationService.NotifyClientOrderCreated(order!, client);
    }

    public async Task<OrderDto?> ChangeOrderAsync(string masterId, Guid orderId, ChangeOrderRequest request)
    {
        var order = await orderRepository.GetByIdAsync(orderId);

        if (order is null)
            return null;
        
        if (order.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the order");

        await ChangeOrderDetailsAsync(order, request);

        await orderRepository.SaveChangesAsync();
        return order.ToDto();
    }

    public async Task<bool> TryDeleteOrderAsync(string masterid, Guid orderId)
    {
        var order = await orderRepository.GetByIdAsync(orderId);

        if (order == null)
            return false;

        if (order.MasterId != masterid)
            throw new ForbidException("Current user is not the owner of the order");

        var clientId = order.ClientId;

        orderRepository.Delete(order);

        await DeleteClientIfNoOrdersAsync(clientId);

        await orderRepository.SaveChangesAsync();
        return true;
    }
    
    private async Task<List<OrderProduct>> GetProductsForOrderAsync(string masterId, IEnumerable<OrderProductRequest> productRequests)
    {
        var products = new List<OrderProduct>();

        foreach (var productRequest in productRequests)
        {
            var product = await productRepository.GetByIdAsync(productRequest.ProductId)
                          ?? throw new NotFoundException("Product not found");

            if (product.MasterId != masterId)
                throw new ForbidException($"Product \"{product.Name}\" from another master");

            products.Add(new OrderProduct
            {
                ProductId = productRequest.ProductId,
                Quantity = productRequest.Quantity,
                UnitPrice = product.Price
            });
        }

        return products;
    }

    private async Task ChangeOrderDetailsAsync(Order order, ChangeOrderRequest request)
    {
        if (request.TotalAmount != null || request.Comment != null || request.Address != null || request.IsCalculationAutomated != null)
            await ChangeOrderInfoAsync(order, request);

        if (request.StageTab != null)
            await ChangeOrderStageAsync(order, (short)request.StageTab);

        if (request.Client != null)
            await ChangeOrderClientAsync(order, request.Client);

        if (request.Products != null)
            await ChangeOrderProductsAsync(order, request.Products);
    }
    
    private async Task ChangeOrderInfoAsync(Order order, ChangeOrderRequest request)
    {
        double? changedTotalAmount = null;
        string? changedComment = null;
        string? changedAddress = null;
        bool? changedCalculation = null;
        if (request.TotalAmount != null && Math.Abs(order.TotalAmount - (double)request.TotalAmount) > 0.000001)
        {
            order.TotalAmount = (double)request.TotalAmount;
            changedTotalAmount = (double)request.TotalAmount;
        }
        if (request.Comment != null && order.Comment != request.Comment)
        {
            order.Comment = request.Comment;
            changedComment = request.Comment;
        }
        if (request.Address != null && order.Address != request.Address)
        {
            order.Address = request.Address;
            changedAddress = request.Address;
        }

        if (request.IsCalculationAutomated != null && order.IsCalculationAutomated != request.IsCalculationAutomated)
        {
            order.IsCalculationAutomated = (bool)request.IsCalculationAutomated;
            changedCalculation = (bool)request.IsCalculationAutomated;
        }

        await historyService.AddOrderChangedHistoryAsync(
            order.Id, changedTotalAmount, changedComment, changedAddress, changedCalculation, DateTime.UtcNow);
    }

    private async Task ChangeOrderStageAsync(Order order, short stageTab)
    {
        var newStage = await stageRepository.GetWithTabByMaster(order.MasterId, stageTab)
                       ?? throw new NotFoundException("Stage not found");
        
        if (order.StageId != newStage.Id)
        {
            await historyService.AddStageChangedHistoryAsync(order.Id, order.Stage, newStage, DateTime.UtcNow);
            order.StageId = newStage.Id;
            await notificationService.NotifyOrderStageChangedAsync(order, newStage.Name);
        }
    }

    /// <summary>
    /// Updates order's client or create new one
    /// </summary>
    private async Task ChangeOrderClientAsync(Order order, ChangeOrderClientRequest request)
    {
        string? changedFullname = null;
        string? changedEmail = null;
        string? changedPhone = null;

        Client? client;
        if (request.Email != null && order.Client.Email != request.Email)
        {
            // email changed
            var oldClientId = order.ClientId;
            
            changedEmail = request.Email;
            client = await clientRepository.GetByEmailAsync(changedEmail);

            if (client == null)
            {
                client = new Client(order.MasterId, request.FullName!, changedEmail, request.Phone!);
                await clientRepository.CreateAsync(client);
            }
            
            order.ClientId = client.Id;
            await DeleteClientIfNoOrdersAsync(oldClientId);
        }
        else
            client = order.Client;
        
        if (request.FullName != null && client.GetFullName() != request.FullName)
        {
            client.SetFullName(request.FullName);
            changedFullname = request.FullName;

            foreach (var clientOrder in client.Orders)
                clientOrder.Name = client.GetInitials();
        }

        if (request.Phone != null && client.Phone != request.Phone)
        {
            client.Phone = request.Phone;
            changedPhone = request.Phone;
        }

        await historyService.AddClientChangedHistoryAsync(
            order.Id, changedFullname, changedEmail, changedPhone, DateTime.UtcNow);
    }
    
    private async Task DeleteClientIfNoOrdersAsync(Guid clientId)
    {
        var client = await clientRepository.GetByIdAsync(clientId);
        if (client!.Orders.Count <= 1)
            clientRepository.Delete(client);
    }

    private async Task ChangeOrderProductsAsync(Order order, IEnumerable<OrderProductRequest> request)
    {
        var products = new List<OrderProduct>();
        var orderProducts = order.OrderProducts;
        var isProductsChanged = false;
        
        foreach (var productRequest in request)
        {
            var product = await productRepository.GetByIdAsync(productRequest.ProductId)
                ?? throw new NotFoundException("Product not found");
            
            if (product.MasterId != order.MasterId)
                throw new ForbidException($"Product \"{product.Name}\" from another master");

            if (!orderProducts.Any(oProduct => 
                    productRequest.ProductId == product.Id && oProduct.Quantity == productRequest.Quantity))
                isProductsChanged = true;

            products.Add(new OrderProduct
            {
                ProductId = productRequest.ProductId,
                Quantity = productRequest.Quantity,
                UnitPrice = product.Price
            });
        }
            
        order.OrderProducts.Clear();
        order.OrderProducts.AddRange(products);
            
        await historyService.AddOrderProductsChangedHistoryAsync(order.Id, isProductsChanged ? products : null, DateTime.UtcNow);
    }
    
    private async Task<Client> CreateOrSetClientAsync(Order order, string fullname, string email, string phone)
    {
        var client = await clientRepository.GetByEmailAsync(email);
        
        if (client == null)
        {
            // Client not found - create new one
            client = new Client(order.MasterId, fullname, email, phone);
            await clientRepository.CreateAsync(client);
        }
        else 
            client.Update(fullname, null, phone);

        order.ClientId = client.Id;
        return client;
    }
}