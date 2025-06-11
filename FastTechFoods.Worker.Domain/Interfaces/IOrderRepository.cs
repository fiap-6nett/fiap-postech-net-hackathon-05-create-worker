using FastTechFoods.Worker.Domain.Entities;

namespace FastTechFoods.Worker.Domain.Interfaces;

public interface IOrderRepository
{
    public Order GetById(Guid id);
    public void RegisterOrder(Order order);
    
}