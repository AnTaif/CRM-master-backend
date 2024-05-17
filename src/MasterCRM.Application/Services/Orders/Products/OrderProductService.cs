using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Orders.Products.Requests;
using MasterCRM.Application.Services.Orders.Products.Responses;
using MasterCRM.Application.Services.Products;
using MasterCRM.Domain.Entities.Orders;

namespace MasterCRM.Application.Services.Orders.Products;

public class OrderProductService(IOrderProductRepository orderProductRepository, IProductRepository productRepository) : IOrderProductService
{
    public async Task<OrderProductDto?> UpdateAsync(Guid orderProductId, OrderProductRequest request)
    {
        var orderProduct = await orderProductRepository.GetByIdAsync(orderProductId);

        if (orderProduct == null)
            return null;

        var unitPrice = orderProduct.UnitPrice;
        if (orderProduct.ProductId != request.ProductId)
        {
            var product = await productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
                throw new Exception("Product not found");
                
            unitPrice = product.Price;
        }

        orderProduct.Update(request.ProductId, request.Quantity, unitPrice);

        await orderProductRepository.SaveChangesAsync();

        return orderProduct.ToDto();
    }

    public async Task<OrderProductDto> CreateAsync(Guid orderId, OrderProductRequest request)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId);

        if (product == null)
            throw new Exception("Product not found");
        
        var orderProduct = new OrderProduct
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            UnitPrice = product.Price
        };

        await orderProductRepository.CreateAsync(orderProduct);
        await orderProductRepository.SaveChangesAsync();

        return orderProduct.ToDto();
    }

    public async Task<bool> TryDeleteAsync(Guid orderProductId)
    {
        var orderProduct = await orderProductRepository.GetByIdAsync(orderProductId);

        if (orderProduct == null)
            return false;

        orderProductRepository.Delete(orderProduct);
        await orderProductRepository.SaveChangesAsync();

        return true;
    }
}