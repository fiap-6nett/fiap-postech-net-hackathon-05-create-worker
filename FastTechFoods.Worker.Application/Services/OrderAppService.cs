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
    
    public Task RegisterOrder(OrderDto dto)
    {
        var items = dto.Items.Select(i => new Item(
                    id: i.Id,
                    menuItemId: i.MenuItemId,
                    name: i.Name,
                    description: i.Description,
                    price: i.Price,
                    amount: i.Amount,
                    category: i.Category,
                    notes: i.Notes
                    )).ToList();

        // Calcula o total do pedido somando (preço * quantidade) de cada item
        var total = items.Sum(item => item.Price * item.Amount);

        var order = new Order
        {
            CreatedAt = dto.CreatedAt,
            IdStore = dto.IdStore,
            IdUser = dto.IdUser,
            Status = OrderStatus.Created,
            DeliveryType = dto.DeliveryType,
            Items = items,
            Total = total,
            Justification = dto.Justification
        };

        _orderRepository.RegisterOrder(order);
        
        return Task.CompletedTask;

    }
}