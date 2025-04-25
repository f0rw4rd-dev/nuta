using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.Aggregates.User.ValueObjects;

public class IngredientPreferences : ValueObject
{
    public bool IsVegan { get; }

    public bool IsVegetarian { get; }

    public bool PrefersPalmOilFree { get; }

    private IngredientPreferences()
    {
    }

    private IngredientPreferences(
        bool isVegan,
        bool isVegetarian,
        bool prefersPalmOilFree)
    {
        IsVegan = isVegan;
        IsVegetarian = isVegetarian;
        PrefersPalmOilFree = prefersPalmOilFree;
    }

    public static IngredientPreferences Create()
    {
        return new IngredientPreferences(
            isVegan: false,
            isVegetarian: false,
            prefersPalmOilFree: false);
    }
}