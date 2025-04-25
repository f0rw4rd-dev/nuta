using Nuta.BuildingBlocks.Domain;

namespace Nuta.Products.Domain.Aggregates.Product.ValueObjects;

public class Labels : ValueObject
{
    public bool HasRussianQualityMark { get; }
    
    private Labels()
    {
    }
    
    private Labels(bool hasRussianQualityMark)
    {
        HasRussianQualityMark = hasRussianQualityMark;
    }
    
    public static Labels Create(bool hasRussianQualityMark)
    {
        return new Labels(hasRussianQualityMark);
    }
}