using Nuta.BuildingBlocks.Domain;
using Nuta.Products.Domain.Aggregates.Additive.Enums;

namespace Nuta.Products.Domain.Aggregates.Additive;

public class Additive : Entity, IAggregateRoot
{
    public AdditiveId Id { get; }
    
    public string Name { get; private set; }
    
    public string ChemicalName { get; private set; }
    
    public string? ENumber { get; private set; }
    
    public string? Description { get; private set; }
    
    public AdditiveRiskLevel RiskLevel { get; private set; }
    
    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; private set; }

    private Additive()
    {
    }
    
    private Additive(AdditiveId id)
    {
        Id = id;
    }
    
    public static Additive Create(AdditiveId id)
    {
        return new Additive(id);
    }
}