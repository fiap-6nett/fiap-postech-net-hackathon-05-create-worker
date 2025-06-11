using FastTechFoods.Worker.Domain.Enums;

namespace FastTechFoods.Worker.Domain.Entities;

public class Order : Base
{
    public Guid IdStore { get; set; }
    public Guid IdUser { get; set; }
    public OrderStatus Status { get; set; }
    public DeliveryType DeliveryType { get; set; }
    public IEnumerable<Item> Items { get; set; }            
}