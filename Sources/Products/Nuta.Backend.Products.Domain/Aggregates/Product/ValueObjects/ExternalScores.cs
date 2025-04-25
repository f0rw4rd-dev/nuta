using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.Aggregates.Product.ValueObjects;

public class ExternalScores : ValueObject
{
    public float? RoskachestvoScore { get; }
    
    private ExternalScores()
    {
    }
    
    private ExternalScores(float? roskachestvoScore)
    {
        RoskachestvoScore = roskachestvoScore;
    }
    
    public static ExternalScores Create(float? roskachestvoScore)
    {
        return new ExternalScores(roskachestvoScore);
    }
}