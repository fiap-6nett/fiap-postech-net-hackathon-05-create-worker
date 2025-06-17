using FastTechFoods.Worker.Domain.Entities;
using FastTechFoods.Worker.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastTechFoods.Worker.Application.Dtos;

#nullable disable
public class OrderDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }

    [Required(ErrorMessage = "Id Store is required")]
    public Guid IdStore { get; set; }

    [Required(ErrorMessage = "Id User is required")]
    public Guid IdUser { get; set; }

    [Required(ErrorMessage = "Status is required")]
    public OrderStatus Status { get; set; }

    [Required(ErrorMessage = "Delivery Type is required")]
    public DeliveryType DeliveryType { get; set; }
    
    [Required(ErrorMessage = "Items is required")]
    public IEnumerable<ItemDto> Items { get; set; }    
    public string Justification { get; set; }    
}
#nullable restore