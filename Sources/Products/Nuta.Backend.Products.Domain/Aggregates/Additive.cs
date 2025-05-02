using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;
using Nuta.Backend.Products.Domain.Enums;

namespace Nuta.Backend.Products.Domain.Aggregates;

public class Additive : Entity, IAggregateRoot
{
    public Guid Id { get; }

    public string Name { get; private set; } = null!;

    public string ChemicalName { get; private set; } = null!;

    public string? ENumber { get; private set; }

    public string? Description { get; private set; }

    public AdditiveRiskLevel RiskLevel { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set; }

    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private Additive()
    {
        // EF Core
    }

    private Additive(
        Guid id,
        string name,
        string checmicalName,
        string? eNumber,
        string? description,
        AdditiveRiskLevel riskLevel)
    {
        Id = id;
        Name = name.Trim();
        ChemicalName = checmicalName.Trim();
        ENumber = eNumber?.Trim();
        Description = description?.Trim();
        RiskLevel = riskLevel;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public static Additive Create(
        string name,
        string chemicalName,
        string? eNumber,
        string? description,
        AdditiveRiskLevel riskLevel)
    {
        return new Additive(id: Guid.CreateVersion7(), name, chemicalName, eNumber, description, riskLevel);
    }

    public void SetName(string name)
    {
        Name = name.Trim();
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetChemicalName(string chemicalName)
    {
        ChemicalName = chemicalName.Trim();
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetENumber(string? eNumber)
    {
        ENumber = eNumber?.Trim();
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetDescription(string? description)
    {
        Description = description?.Trim();
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetRiskLevel(AdditiveRiskLevel riskLevel)
    {
        RiskLevel = riskLevel;
        UpdatedAt = DateTime.UtcNow;
    }
}