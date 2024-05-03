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
    public async Task<IEnumerable<GetOrderItemResponse>> GetWithStageByMasterAsync(string masterId, short orderTab)
    {
        var activeOrders = await orderRepository.GetAllByPredicateAsync(order =>
            order.MasterId == masterId && order.IsActive && order.Stage.Order == orderTab);
        
        return activeOrders.Select(order => order.ToItemResponse());
    }

    public async Task<OrderDto?> GetOrderByIdAsync(Guid orderId)
    {
        var order = await orderRepository.GetByIdAsync(orderId);
        
        return order?.ToDto();
    }

    public async Task<OrderDto> CreateOrderAsync(string masterId, CreateOrderRequest request)
    {
        var client = await clientRepository.GetByEmailAsync(request.Client.Email);
        
        Guid clientId;
        if (client == null)
        {
            var newClient = new Client(masterId, request.Client.FullName, request.Client.Email, request.Client.Phone);
            await clientRepository.CreateAsync(newClient);
            clientId = newClient.Id;
        }
        else
        {
            client.LastOrderDate = DateTime.UtcNow;
            clientRepository.Update(client);
            clientId = client.Id;
        }

        var startStage = await stageRepository.GetStartByMasterAsync(masterId);

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
            ClientId = clientId,
            Address = request.Address,
            StageId = startStage.Id,
            TotalAmount = request.TotalAmount,
            Comment = request.Comment,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            OrderProducts = products
        };
        
        await orderRepository.CreateAsync(newOrder);

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
            Client? client;
            if (request.Client.Email == null)
                client = order.Client;
            else 
                client = await clientRepository.GetByEmailAsync(request.Client.Email);

            if (client == null)
            {
                // Create new client
                var newClient = new Client(masterId, 
                    request.Client.FullName ?? order.Client.GetFullName(), 
                    request.Client.Email!, 
                    request.Client.Phone ?? order.Client.Phone);
                
                await clientRepository.CreateAsync(newClient);
                order.ClientId = newClient.Id;
            }
            else
            {
                client.Update(request.Client.FullName, null, request.Client.Phone);
                order.ClientId = client.Id;
            }
            
            var updateClientHistory = new OrderHistory
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                Change = $"{request.Client.FullName ?? ""} {request.Client.Email ?? ""} {request.Client.Phone ?? ""}",
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