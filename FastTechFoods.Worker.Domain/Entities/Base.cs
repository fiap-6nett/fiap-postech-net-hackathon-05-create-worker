namespace FastTechFoods.Worker.Domain.Entities
{
    public abstract class Base
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}