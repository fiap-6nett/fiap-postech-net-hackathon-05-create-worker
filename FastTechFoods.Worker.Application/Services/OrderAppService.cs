using FastTechFoods.Worker.Application.Dtos;
using FastTechFoods.Worker.Application.Interfaces;
using FastTechFoods.Worker.Domain.Entities;
using FastTechFoods.Worker.Domain.Enums;
using FastTechFoods.Worker.Domain.Interfaces;

namespace FastTechFoods.Worker.Application.Services;

public class OrderAppService : IOrderAppService
{
    private readonly IOrderRepository _orderRepository;
    
    public OrderAppService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public Task RegisterOrder(OrderPostDto dto)
    {       
        var order = new Order
        {
            IdStore = dto.IdStore,
            IdUser = dto.IdUser,
            Status = OrderStatus.Created,
            DeliveryType = dto.DeliveryType
        };

        order.OrderItems.AddRange(
            dto.OrderItems.Select(item =>
                new OrderItem(
                    item
                    order.Id,
                    item.MenuItemId,
                    item.Quantity,
                    item.Price,
                    item.Notes
                )
            )
        );

        _orderRepository.RegisterOrder(order);
        
        return Task.CompletedTask;

    }
}