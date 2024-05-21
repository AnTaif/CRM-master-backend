using MasterCRM.Application.MapExtensions;
using MasterCRM.Application.Services.Orders.Products.Requests;
using MasterCRM.Application.Services.Orders.Products.Responses;
using MasterCRM.Application.Services.Products;
using MasterCRM.Domain.Entities.Orders;
using MasterCRM.Domain.Exceptions;

namespace MasterCRM.Application.Services.Orders.Products;

public class OrderProductService(IOrderProductRepository orderProductRepository, IProductRepository productRepository) : IOrderProductService
{
    public async Task<OrderProductDto?> UpdateAsync(string masterId, Guid orderProductId, OrderProductRequest request)
    {
        var orderProduct = await orderProductRepository.GetByIdAsync(orderProductId);

        if (orderProduct == null)
            return null;
        
        if (orderProduct.Product.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the order");

        var unitPrice = orderProduct.UnitPrice;
        if (orderProduct.ProductId != request.ProductId)
        {
            var product = await productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
                throw new NotFoundException("Product not found");
                
            unitPrice = product.Price;
        }

        orderProduct.Update(request.ProductId, request.Quantity, unitPrice);

        await orderProductRepository.SaveChangesAsync();

        return orderProduct.ToDto();
    }

    public async Task<OrderProductDto> CreateAsync(string masterId, Guid orderId, OrderProductRequest request)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId);

        if (product == null)
            throw new NotFoundException("Product not found");
        
        if (product.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the order");
        
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

    public async Task<bool> TryDeleteAsync(string masterId, Guid orderProductId)
    {
        var orderProduct = await orderProductRepository.GetByIdAsync(orderProductId);
        
        if (orderProduct == null)
            return false;
        
        if (orderProduct.Product.MasterId != masterId)
            throw new ForbidException("Current user is not the owner of the order");

        orderProductRepository.Delete(orderProduct);
        await orderProductRepository.SaveChangesAsync();

        return true;
    }
}