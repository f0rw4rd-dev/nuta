using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.ValueObjects;

public class NutritionPreferences : ValueObject
{
    public bool PrefersLowFat { get; }
    
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private NutritionPreferences()
    {
    }

    private NutritionPreferences(bool prefersLowFat)
    {
        PrefersLowFat = prefersLowFat;
    }

    public static NutritionPreferences Create(bool prefersLowFat = false)
    {
        return new NutritionPreferences(prefersLowFat);
    }
}