using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.ValueObjects;

public class Ingredients : ValueObject
{
    public IReadOnlyCollection<Guid> AdditiveIds = null!;
    
    public IReadOnlyCollection<string> Names = null!;
    
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private Ingredients()
    {
        // EF Core
    }

    private Ingredients(IReadOnlyCollection<Guid> additiveIds, IReadOnlyCollection<string> names)
    {
        AdditiveIds = additiveIds;
        Names = names;
    }
    
    public static Ingredients Create(
        IReadOnlyCollection<Guid>? additiveIds = null, 
        IReadOnlyCollection<string>? names = null)
    {
        return new Ingredients(additiveIds ?? [], names ?? []);
    }
}