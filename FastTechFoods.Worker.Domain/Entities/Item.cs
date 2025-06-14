using FastTechFoods.Worker.Domain.Enums;

namespace FastTechFoods.Worker.Domain.Entities;

#nullable disable
public class Item
{    
    public Guid Id { get; set; }
    public Guid MenuItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Amount { get; set; }
    public Category Category { get; set; }
    public string Notes { get; set; }

    public Item(Guid id, Guid menuItemId, string name, string description, decimal price, decimal amount, Category category, string notes)
    {        
        Id = id;
        MenuItemId = menuItemId;
        Name = name;
        Description = description;
        Price = price;
        Amount = amount;
        Category = category;
        Notes = notes;
    }

    public Item() { }

}
#nullable restore
