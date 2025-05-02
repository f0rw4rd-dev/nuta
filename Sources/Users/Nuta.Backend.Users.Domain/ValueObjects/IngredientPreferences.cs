using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.ValueObjects;

public class IngredientPreferences : ValueObject
{
    public bool IsVegan { get; }

    public bool IsVegetarian { get; }

    public bool PrefersPalmOilFree { get; }

    [SuppressMessage("ReSharper", "UnusedMember.Local")]
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

    public static IngredientPreferences Create(
        bool isVegan = false,
        bool isVegetarian = false,
        bool prefersPalmOilFree = false)
    {
        return new IngredientPreferences(
            isVegan,
            isVegetarian,
            prefersPalmOilFree);
    }
}