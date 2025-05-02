using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.ValueObjects;

public class ExternalScores : ValueObject
{
    public double? RoskachestvoScore { get; }
    
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private ExternalScores()
    {
        // EF Core
    }
    
    private ExternalScores(double? roskachestvoScore)
    {
        RoskachestvoScore = roskachestvoScore;
    }
    
    public static ExternalScores Create(double? roskachestvoScore)
    {
        return new ExternalScores(roskachestvoScore);
    }
}