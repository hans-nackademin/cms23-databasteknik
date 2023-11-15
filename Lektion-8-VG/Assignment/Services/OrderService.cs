using Assignment.Entities;
using Assignment.Models;
using Assignment.Repositories;

namespace Assignment.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly OrderRowRepository _orderRowRepository;
    private readonly CustomerRepository _customerRepository;
    private readonly ProductRepository _productRepository;

    public OrderService(OrderRepository orderRepository, OrderRowRepository orderRowRepository, CustomerRepository customerRepository, ProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _orderRowRepository = orderRowRepository;
        _customerRepository = customerRepository;
        _productRepository = productRepository;
    }

    public async Task CreateOrderAsync(ShoppingCart shoppingCart)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.Id == shoppingCart.CustomerId);
        if (customerEntity != null) 
        {
            var orderEntity = await _orderRepository.CreateAsync(new OrderEntity()
            {
                OrderDate = DateTime.Now,
                CustomerId = customerEntity.Id,
            });

            if (orderEntity != null)
            {
                foreach (var item in shoppingCart.Items)
                {
                    var productEntity = await _productRepository.GetAsync(x => x.Id == item.ProductId);

                    if (productEntity != null)
                    {
                        await _orderRowRepository.CreateAsync(new OrderRowEntity
                        {
                            OrderId = orderEntity.Id,
                            ProductId = productEntity.Id,
                            Price = productEntity.ProductPrice,
                            Quantity = item.Quantity,
                        });

                        orderEntity.TotalPrice += (productEntity.ProductPrice * item.Quantity);
                    }
                }

                await _orderRepository.UpdateAsync(orderEntity);
            }
        }
    }
}
