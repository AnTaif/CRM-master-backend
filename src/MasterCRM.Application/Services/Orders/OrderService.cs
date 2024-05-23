using System.Text;
using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Clients;
using MasterCRM.Application.Services.Orders.History;
using MasterCRM.Application.Services.Orders.Products.Requests;
using MasterCRM.Application.Services.Orders.Requests;
using MasterCRM.Application.Services.Orders.Responses;
using MasterCRM.Application.Services.Orders.Stages;
using MasterCRM.Application.Services.Products;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;
using MasterCRM.Domain.Exceptions;
using MasterCRM.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MasterCRM.Application.Services.Orders;

public class OrderService(
    IOrderRepository orderRepository, 
    IClientRepository clientRepository,
    IStageRepository stageRepository,
    IProductRepository productRepository,
    IOrderHistoryService historyService,
    IEmailSender emailSender,
    UserManager<Master> userManager) : IOrderService
{
    public async Task<GetOrdersResponse> GetAllByMasterAsync(string masterId)
    {
        var orders = await orderRepository.GetAllByPredicateAsync(order =>
            order.MasterId == masterId);

        var ordersArray = orders.ToArray();
        return new GetOrdersResponse(ordersArray.Length, ordersArray.Select(order => order.ToItemResponse()));
    }
    
    public async Task<GetOrdersResponse> GetWithStageByMasterAsync(string masterId, short orderTab)
    {
        var activeOrders = await orderRepository.GetAllByPredicateAsync(order =>
            order.MasterId == masterId && order.Stage.Order == orderTab);

        var orders = activeOrders.ToArray();
        return new GetOrdersResponse(orders.Length, orders.Select(order => order.ToItemResponse()));
    }

    public async Task<OrderDto?> GetOrderByIdAsync(string masterid, Guid orderId)
    {
        var order = await orderRepository.GetByIdAsync(orderId);

        if (order == null)
            return null;
        
        if (order.MasterId != masterid)
            throw new ForbidException("Current user is not the owner of the order");
        
        return order.ToDto();
    }

    public async Task<OrderDto> CreateOrderAsync(string masterId, CreateOrderRequest request)
    {
        var stage = await stageRepository.GetWithTabByMaster(masterId, request.StageTab);

        if (stage == null)
            throw new NotFoundException($"Stage with tab \"{request.StageTab}\" not found");

        var products = new List<OrderProduct>();

        foreach (var productRequest in request.Products)
        {
            var product = await productRepository.GetByIdAsync(productRequest.ProductId);
            
            if (product == null)
                throw new NotFoundException("Product not found");

            products.Add(new OrderProduct
            {
                ProductId = productRequest.ProductId,
                Quantity = productRequest.Quantity,
                UnitPrice = product.Price
            });
        }
        
        var newOrder = new Order
        {
            Id = Guid.NewGuid(),
            MasterId = masterId,
            Name = GetOrderName(request.Client.FullName),
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
        
        await NotifyClientOrderCreated(order!, client);
        
        return newOrder.ToDto();
    }

    public async Task CreateOrderForWebsiteAsync(Guid websiteId, CreateWebsiteOrderRequest request)
    {
        var master = await userManager.Users.FirstOrDefaultAsync(master => master.WebsiteId == websiteId);

        if (master == null)
            throw new NotFoundException("Website not found");
        
        var masterId = master.Id;
        
        var stage = await stageRepository.GetStartByMasterAsync(masterId);

        if (stage == null)
            throw new NotFoundException("Start stage not found");
        
        var products = new List<OrderProduct>();
        var totalAmount = 0.0; 

        foreach (var productRequest in request.Products)
        {
            var product = await productRepository.GetByIdAsync(productRequest.ProductId);
            
            if (product == null)
                throw new NotFoundException("Product not found");

            products.Add(new OrderProduct
            {
                ProductId = productRequest.ProductId,
                Quantity = productRequest.Quantity,
                UnitPrice = product.Price
            });

            totalAmount += product.Price * productRequest.Quantity;
        }
        
        var newOrder = new Order
        {
            Id = Guid.NewGuid(),
            MasterId = masterId,
            Name = GetOrderName(request.Client.FullName),
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

        await NotifyMasterOrderCreated(order!, client);
        await NotifyClientOrderCreated(order!, client);
    }

    private async Task NotifyMasterOrderCreated(Order order, Client client)
    {
        if (order.Master.Email != null)
        {
            var message = $"Доброго дня, {order.Master.GetFullName()}.\nПользователь {client.GetFullName()} оставил заявку на заказ.\n" +
                          (string.IsNullOrWhiteSpace(order.Comment) ? $"Комментарий к заказу - {order.Comment}.\n" : "") +
                          $"Контактные данные пользователя для связи: {client.Phone}, {client.Email}.\nС уважением,\nМастерскаЯ\n";
            await emailSender.SendEmailAsync(order.Master.Email, "У вас новый заказ!", message);
        }
    }

    private async Task NotifyClientOrderCreated(Order order, Client client)
    {
        var clientMessage =
            $"Доброго дня, {client.GetFullName()}.\nВаш заказ успешно оформлен и отправлен мастеру.\nО переходе товара на следующую стадию вы узнаете в письме, которое придет на эту же почту.\nКонтактные данные мастера для связи: {order.Master.PhoneNumber}, {order.Master.Email}.\nС уважением,\nМастерскаЯ\n";
        await emailSender.SendEmailAsync(client.Email, "Ваш заказ оформлен", clientMessage);
    }
    
    private async Task<Client> CreateOrSetClientAsync(Order order, string fullnameRequest, string emailRequest, string phoneRequest)
    {
        var client = await clientRepository.GetByEmailAsync(emailRequest);

        if (client == null)
        {
            // Client not found - create new one
            var newClient = new Client(order.MasterId, fullnameRequest, emailRequest, phoneRequest, order.CreatedAt);
            await clientRepository.CreateAsync(newClient);
            order.ClientId = newClient.Id;
            return newClient;
        }

        client.Update(fullnameRequest, null, phoneRequest);
        order.ClientId = client.Id;
        return client;
    }

    public async Task<OrderDto?> ChangeOrderAsync(string masterId, Guid orderId, ChangeOrderRequest request)
    {
        var order = await orderRepository.GetByIdAsync(orderId);

        if (order is null)
            return null;
        
        if (order.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the order");
        
        if (request.TotalAmount != null || request.Comment != null || request.Address != null || request.IsCalculationAutomated != null)
            await ChangeOrderInfoAsync(order, request);

        Stage? newStage = null;
        if (request.StageTab != null)
            newStage = await ChangeOrderStageAsync(order, masterId, (short)request.StageTab);
        
        if (request.Client != null)
            await ChangeOrderClientAsync(order, masterId, request.Client);
        
        if (request.Products != null)
            await ChangeOrderProductsAsync(order, request.Products);
        
        orderRepository.Update(order);
        
        await orderRepository.SaveChangesAsync();

        if (newStage != null)
            await NotifyOrderStageChangedAsync(order, newStage.Name);

        return order.ToDto();
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

    private async Task<Stage?> ChangeOrderStageAsync(Order order, string masterId, short stageTab)
    {
        var stage = await stageRepository.GetWithTabByMaster(masterId, stageTab);
            
        if (stage == null)
            throw new NotFoundException("Stage not found");
        
        if (order.Stage.Order == stageTab)
            return null;
            
        await historyService.AddStageChangedHistoryAsync(
            order.Id, order.Stage, stage, DateTime.UtcNow);
            
        order.StageId = stage.Id;
        return stage;
    }

    private async Task NotifyOrderStageChangedAsync(Order order, string newStage)
    {
        var message = $"Доброго дня, {order.Client.GetFullName()}.\nВаш заказ от {order.CreatedAt} перешел на следующую стадию {newStage}.\nКонтактные данные мастера для связи: {order.Master.PhoneNumber}, {order.Master.Email}.\nС уважением,\nМастерскаЯ";
        await emailSender.SendEmailAsync(order.Client.Email, "Ваш заказ перешел на следующую стадию!", message);
    }

    /// <summary>
    /// Updates order's client or create new one
    /// </summary>
    private async Task ChangeOrderClientAsync(Order order, string masterId, ChangeOrderClientRequest request)
    {
        string? changedFullname = null;
        string? changedEmail = null;
        string? changedPhone = null;

        Client? client;
        if (request.Email != null && order.Client.Email != request.Email)
        {
            // email changed
            changedEmail = request.Email;
            client = await clientRepository.GetByEmailAsync(changedEmail);

            if (client == null)
            {
                // Client not found - create new one
                client = new Client(masterId, request.FullName!, request.Email, request.Phone!, order.CreatedAt);
                await clientRepository.CreateAsync(client);
                order.ClientId = client.Id;
            }
            else
                order.ClientId = client.Id;
        }
        else
            client = order.Client;
        
        if (request.FullName != null && client.GetFullName() != request.FullName)
        {
            client.SetFullName(request.FullName);
            changedFullname = request.FullName;
        }

        if (request.Phone != null && client.Phone != request.Phone)
        {
            client.Phone = request.Phone;
            changedPhone = request.Phone;
        }

        await historyService.AddClientChangedHistoryAsync(
            order.Id, changedFullname, changedEmail, changedPhone, DateTime.UtcNow);
    }

    private async Task ChangeOrderProductsAsync(Order order, IEnumerable<OrderProductRequest> request)
    {
        var products = new List<OrderProduct>();
        var orderProducts = order.OrderProducts;
        var isProductsChanged = false;
        
        foreach (var productRequest in request)
        {
            var product = await productRepository.GetByIdAsync(productRequest.ProductId);
            
            if (product == null)
                throw new NotFoundException("Product not found");

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

    public async Task<bool> TryDeleteOrderAsync(string masterid, Guid orderId)
    {
        var order = await orderRepository.GetByIdAsync(orderId);

        if (order == null)
            return false;

        if (order.MasterId != masterid)
            throw new ForbidException("Current user is not the owner of the order");

        var clientId = order.ClientId;

        orderRepository.Delete(order);

        var client = await clientRepository.GetByIdAsync(clientId);
        if (client!.Orders.Count <= 1)
            clientRepository.Delete(client);

        await orderRepository.SaveChangesAsync();
        return true;
    }
    
    private string GetOrderName(string fullname)
    {
        var splitFullname = fullname.Split();
        var name = new StringBuilder();

        name.Append(splitFullname[0]);
        name.Append($" {splitFullname[1][0]}.");
        if (splitFullname.Length > 2)
            name.Append($"{splitFullname[2][0]}.");
        return name.ToString();
    }
}