using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.Aggregates.Manufacturer;

public class Manufacturer : Entity, IAggregateRoot
{
    public ManufacturerId Id { get; }
    
    public string Name { get; private set; }
    
    public string? Description { get; private set; }
    
    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; private set; }

    private Manufacturer()
    {
    }
    
    private Manufacturer(ManufacturerId id, string name)
    {
        Id = id;
        Name = name.Trim();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public static Manufacturer Create(ManufacturerId id, string name)
    {
        return new Manufacturer(id, name);
    }
    
    public void SetName(string name)
    {
        Name = name.Trim();
        UpdatedAt = DateTime.UtcNow;
    }
}