using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.ValueObjects;

public class ProductLabels : ValueObject
{
    public bool HasRussianQualityMark { get; }
    
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private ProductLabels()
    {
        // EF Core
    }
    
    private ProductLabels(bool hasRussianQualityMark)
    {
        HasRussianQualityMark = hasRussianQualityMark;
    }
    
    public static ProductLabels Create(bool hasRussianQualityMark)
    {
        return new ProductLabels(hasRussianQualityMark);
    }
}