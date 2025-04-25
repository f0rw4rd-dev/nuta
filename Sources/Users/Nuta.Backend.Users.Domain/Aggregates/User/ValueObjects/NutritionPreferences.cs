using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.Aggregates.User.ValueObjects;

public class NutritionPreferences : ValueObject
{
    public bool PrefersLowFat { get; }
    
    private NutritionPreferences()
    {
    }

    private NutritionPreferences(bool prefersLowFat)
    {
        PrefersLowFat = prefersLowFat;
    }

    public static NutritionPreferences Create()
    {
        return new NutritionPreferences(prefersLowFat: false);
    }
}