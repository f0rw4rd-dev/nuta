using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.Aggregates;

public class Manufacturer : Entity, IAggregateRoot
{
    public Guid Id { get; }
    
    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }
    
    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; private set; }

    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private Manufacturer()
    {
        // EF Core
    }
    
    private Manufacturer(Guid id, string name, string? description)
    {
        Id = id;
        Name = name.Trim();
        Description = description?.Trim();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
    
    public static Manufacturer Create(string name, string? description)
    {
        return new Manufacturer(id: Guid.CreateVersion7(), name, description);
    }
    
    public void SetName(string name)
    {
        Name = name.Trim();
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void SetDescription(string? description)
    {
        Description = description?.Trim();
        UpdatedAt = DateTime.UtcNow;
    }
}