using System.Text;
using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Clients;
using MasterCRM.Application.Services.Orders.Dto;
using MasterCRM.Application.Services.Orders.History;
using MasterCRM.Application.Services.Orders.Requests;
using MasterCRM.Application.Services.Orders.Responses;
using MasterCRM.Application.Services.Orders.Stages;
using MasterCRM.Application.Services.Products;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;

namespace MasterCRM.Application.Services.Orders;

public class OrderService(
    IOrderRepository orderRepository, 
    IClientRepository clientRepository,
    IStageRepository stageRepository,
    IProductRepository productRepository,
    IOrderHistoryRepository historyRepository) : IOrderService
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

    public async Task<OrderDto?> GetOrderByIdAsync(Guid orderId)
    {
        var order = await orderRepository.GetByIdAsync(orderId);
        
        return order?.ToDto();
    }

    public async Task<OrderDto> CreateOrderAsync(string masterId, CreateOrderRequest request)
    {
        var stage = await stageRepository.GetWithTabByMaster(masterId, request.StageTab);

        if (stage == null)
            throw new Exception($"Stage with tab \"{request.StageTab}\" not found");

        var products = new List<OrderProduct>();

        foreach (var productRequest in request.Products)
        {
            var product = await productRepository.GetByIdAsync(productRequest.ProductId);
            
            if (product == null)
                throw new Exception("Product not found");

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
            Comment = request.Comment,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            OrderProducts = products
        };
        
        await orderRepository.CreateAsync(newOrder);
        
        await CreateOrUpdateClientAsync(newOrder, request.Client.FullName, request.Client.Email, request.Client.Phone);

        var historyItem = new OrderHistory
        {
            Id = Guid.NewGuid(),
            OrderId = newOrder.Id,
            Change = $"Заказ {newOrder.Name}",
            Type = "Создана сделка",
            Date = newOrder.CreatedAt
        };
        await historyRepository.CreateAsync(historyItem);
        
        await orderRepository.SaveChangesAsync();

        return newOrder.ToDto();
    }

    public async Task<OrderDto?> ChangeOrderAsync(string masterId, Guid orderId, ChangeOrderRequest request)
    {
        var order = await orderRepository.GetByIdAsync(orderId);

        if (order is null)
            return null;
        
        if (order.MasterId != masterId)
            throw new Exception("Current user is not the owner of the order");

        order.Update(request.TotalAmount, request.Comment, request.Address);
        
        if (request.TotalAmount != null || request.Comment != null || request.Address != null)
        {
            var updateOrderHistory = new OrderHistory
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                Change = $"{request.TotalAmount} {request.Comment ?? ""} {request.Address ?? ""}",
                Type = "Данные заказа изменены",
                Date = DateTime.UtcNow
            };
            await historyRepository.CreateAsync(updateOrderHistory);   
        }

        if (request.StageTab != null)
        {
            var stage = await stageRepository.GetWithTabByMaster(masterId, (short)request.StageTab);
            
            if (stage == null)
                throw new Exception("Stage not found");
            
            if (stage.MasterId != masterId)
                throw new Exception("Current user is not the owner of the stage");

            var updateStageHistory = new OrderHistory
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                Change = $"{order.Stage.Name} -> {stage.Name}",
                Type = "Этап изменен",
                Date = DateTime.UtcNow
            };
            await historyRepository.CreateAsync(updateStageHistory);
            
            order.StageId = stage.Id;
        }

        // Update client or create new one
        if (request.Client != null)
        {
            var clientRequest = request.Client;
            await CreateOrUpdateClientAsync(order, clientRequest.FullName, clientRequest.Email, clientRequest.Phone);
            
            var updateClientHistory = new OrderHistory
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                Change = $"{clientRequest.FullName ?? ""} {clientRequest.Email ?? ""} {clientRequest.Phone ?? ""}",
                Type = "Данные клиента изменены",
                Date = DateTime.UtcNow
            };
            await historyRepository.CreateAsync(updateClientHistory);
        }
        
        if (request.Products != null)
        {
            var products = new List<OrderProduct>();

            foreach (var productRequest in request.Products)
            {
                var product = await productRepository.GetByIdAsync(productRequest.ProductId);
            
                if (product == null)
                    throw new Exception("Product not found");

                products.Add(new OrderProduct
                {
                    ProductId = productRequest.ProductId,
                    Quantity = productRequest.Quantity,
                    UnitPrice = product.Price
                });
            }
            
            order.OrderProducts.Clear();
            order.OrderProducts.AddRange(products);
            
            var updateOrderProductsHistory = new OrderHistory
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                Change = $"{products.Count} позиций на {products.Sum(product => product.Quantity * product.UnitPrice)} \u20bd",
                Type = "Товары заказа изменены",
                Date = DateTime.UtcNow
            };
            await historyRepository.CreateAsync(updateOrderProductsHistory);
        }
        
        orderRepository.Update(order);
        
        await orderRepository.SaveChangesAsync();

        return order.ToDto();
    }

    public async Task<bool> TryDeleteOrderAsync(Guid orderId)
    {
        var order = await orderRepository.GetByIdAsync(orderId);

        if (order == null)
            return false;

        var clientId = order.ClientId;

        orderRepository.Delete(order);

        var clientOrders = await orderRepository.GetAllByPredicateAsync(o => o.ClientId == clientId);

        if (!clientOrders.Any())
        {
            var client = await clientRepository.GetByIdAsync(clientId);
            clientRepository.Delete(client!);
        }

        await orderRepository.SaveChangesAsync();
        return true;
    }

    private async Task CreateOrUpdateClientAsync(Order order, string? fullnameRequest, string? emailRequest, string? phoneRequest)
    {
        var masterId = order.MasterId;
        var fullname = fullnameRequest ?? order.Client.GetFullName();
        var email = emailRequest ?? order.Client.Email;
        var phone = phoneRequest ?? order.Client.Phone;
        
        var client = await clientRepository.GetByEmailAsync(email);

        if (client == null)
        {
            // Client not found - create new one
            var newClient = new Client(masterId, fullname, email, phone, order.CreatedAt);
            await clientRepository.CreateAsync(newClient);
            order.ClientId = newClient.Id;
        }
        else
        {
            client.Update(fullname, null, phone);
            order.ClientId = client.Id;
        }
    }
    
    private string GetOrderName(string fullname)
    {
        var splitFullname = fullname.Split();
        var name = new StringBuilder("Заказ ");

        name.Append(splitFullname[0]);
        name.Append($" {splitFullname[1][0]}.");
        if (splitFullname.Length > 2)
            name.Append($"{splitFullname[2][0]}.");
        return name.ToString();
    }
}