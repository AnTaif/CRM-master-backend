using System.Text;
using MasterCRM.Application.Services.Clients;
using MasterCRM.Application.Services.Orders.Dto;
using MasterCRM.Application.Services.Orders.Requests;
using MasterCRM.Application.Services.Orders.Responses;
using MasterCRM.Application.Services.Orders.Stages;
using MasterCRM.Application.Services.Product;
using MasterCRM.Domain.Entities;

namespace MasterCRM.Application.Services.Orders;

public class OrderService(
    IOrderRepository orderRepository, 
    IClientRepository clientRepository,
    IStageRepository stageRepository,
    IProductRepository productRepository) : IOrderService
{
    public async Task<IEnumerable<GetOrderItemResponse>> GetWithStageByMasterAsync(string masterId, int orderTab)
    {
        var activeOrders = await orderRepository.GetAllByPredicateAsync(order =>
            order.MasterId == masterId && order.IsActive && order.Stage.Order == orderTab);
        
        return activeOrders.Select(order => new GetOrderItemResponse
        {
            Id = order.Id,
            Name = order.Name,
            Stage = order.Stage.Name,
            TotalAmount = order.TotalAmount,
            Comment = order.Comment,
            Address = order.Address,
            Client = new OrderClientDto
            {
                FullName = order.Client.GetFullName(),
                Email = order.Client.Email,
                Phone = order.Client.Phone,
            }
        });
    }

    public async Task<GetOrderResponse?> GetOrderByIdAsync(Guid orderId)
    {
        var order = await orderRepository.GetByIdAsync(orderId);
        
        if (order is null)
        {
            return null;
        }
        
        return new GetOrderResponse
        {
            Id = order.Id,
            Name = order.Name,
            Stage = order.Stage.Name,
            TotalAmount = order.TotalAmount,
            Comment = order.Comment,
            Address = order.Address,
            Client = new OrderClientDto
            {
                FullName = order.Client.GetFullName(),
                Email = order.Client.Email,
                Phone = order.Client.Phone,
            },
            Products = order.OrderProducts.Select(product => new OrderProductDto
            {
                ProductId = product.Product.Id,
                Name = product.Product.Name,
                Quantity = product.Quantity,
                Photo = product.Product.Photos.First().Url
            })
        };
    }

    public async Task<GetOrderResponse> CreateOrderAsync(string masterId, CreateOrderRequest request)
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
            clientId = client.Id;

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
            OrderProducts = products,
            History = new List<OrderHistory>() // TODO: add new history item
        };
        
        await orderRepository.CreateAsync(newOrder);
        await orderRepository.SaveChangesAsync();

        return new GetOrderResponse
        {
            Id = newOrder.Id,
            Name = newOrder.Name,
            Stage = startStage.Name,
            TotalAmount = newOrder.TotalAmount,
            Comment = newOrder.Comment,
            Client = new OrderClientDto
            {
                FullName = newOrder.Client.GetFullName(),
                Email = newOrder.Client.Email,
                Phone = newOrder.Client.Phone,
            },
            Address = newOrder.Address,
            Products = newOrder.OrderProducts.Select(product => new OrderProductDto
            {
                ProductId = product.Product.Id,
                Name = product.Product.Name,
                Quantity = product.Quantity,
                Photo = product.Product.Photos.First().Url
            })
        };
    }

    public async Task<GetOrderResponse?> ChangeOrderAsync(string masterId, Guid orderId, ChangeOrderRequest request)
    {
        var order = await orderRepository.GetByIdAsync(orderId);

        if (order is null)
            return null;
        
        if (order.MasterId != masterId)
            throw new Exception("Current user is not the owner of the order");

        order.TotalAmount = request.TotalAmount ?? order.TotalAmount;
        order.Comment = request.Comment ?? order.Comment;
        order.Address = request.Address ?? order.Address;

        if (request.StageId != null)
        {
            var stage = await stageRepository.GetByIdAsync(request.StageId.Value);
            
            if (stage == null)
                throw new Exception("Stage not found");
            
            if (stage.MasterId != masterId)
                throw new Exception("Current user is not the owner of the stage");
            
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
                var newClient = new Client(
                    masterId, 
                    request.Client.FullName ?? order.Client.GetFullName(), 
                    request.Client.Email!, 
                    request.Client.Phone ?? order.Client.Phone);
                
                await clientRepository.CreateAsync(newClient);
                order.ClientId = newClient.Id;
            }
            else
            {
                if (request.Client.FullName != null)
                    client.ParseFullName(request.Client.FullName);

                client.Phone = request.Client.Phone ?? order.Client.Phone;
                order.ClientId = client.Id;
            }
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
        }
        
        orderRepository.Update(order);
        await orderRepository.SaveChangesAsync();
        
        return new GetOrderResponse
        {
            Id = order.Id,
            Name = order.Name,
            Stage = order.Stage.Name,
            TotalAmount = order.TotalAmount,
            Comment = order.Comment,
            Address = order.Address,
            Client = new OrderClientDto
            {
                FullName = order.Client.GetFullName(),
                Email = order.Client.Email,
                Phone = order.Client.Phone,
            },
            Products = order.OrderProducts.Select(product => new OrderProductDto
            {
                ProductId = product.Product.Id,
                Name = product.Product.Name,
                Quantity = product.Quantity,
                Photo = product.Product.Photos.First().Url
            })
        };
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
            clientRepository.Delete(client);
        }

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