using MasterCRM.Application.Services.Orders.Products;
using MasterCRM.Application.Services.Orders.Products.Responses;
using MasterCRM.Application.Services.Orders.Responses;
using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;

namespace MasterCRM.Application.MapExtensions;

public static class OrderExtensions
{
    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            Name = order.Name,
            Stage = order.Stage.Name,
            TotalAmount = order.TotalAmount,
            IsCalculationAutomated = order.IsCalculationAutomated,
            Comment = order.Comment,
            Address = order.Address,
            Client = order.Client.ToOrderDto(),
            Products = order.OrderProducts.Select(orderProduct => orderProduct.ToDto())
        };
    }

    public static GetOrderItemResponse ToItemResponse(this Order order)
    {
        return new GetOrderItemResponse
        {
            Id = order.Id,
            Name = order.Name,
            Stage = order.Stage.Name,
            TotalAmount = order.TotalAmount,
            Comment = order.Comment,
            Address = order.Address,
            Date = order.CreatedAt,
            Client = order.Client.ToOrderDto()
        };
    }
}

public static class OrderProductExtensions
{
    public static OrderProductDto ToDto(this OrderProduct orderProduct)
    {
        return new OrderProductDto
        {
            Id = orderProduct.Id,
            ProductId = orderProduct.Product.Id,
            Name = orderProduct.Product.Name,
            Quantity = orderProduct.Quantity,
            Photo = orderProduct.Product.Photos.FirstOrDefault()?.Url
        };
    }
}

public static class ClientOrderExtensions
{
    public static OrderClientDto ToOrderDto(this Client client)
    {
        return new OrderClientDto
        {
            FullName = client.GetFullName(),
            Email = client.Email,
            Phone = client.Phone
        };
    }
}