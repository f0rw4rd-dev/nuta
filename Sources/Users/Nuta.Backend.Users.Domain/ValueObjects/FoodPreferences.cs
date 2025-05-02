using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.ValueObjects;

public class FoodPreferences : ValueObject
{
    public NutritionPreferences NutritionPreferences { get; } = null!;

    public IngredientPreferences IngredientPreferences { get; } = null!;

    public AllergenRestrictions AllergenRestrictions { get; } = null!;


    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private FoodPreferences() 
    {
    }

    private FoodPreferences(
        NutritionPreferences nutritionPreferences,
        IngredientPreferences ingredientPreferences,
        AllergenRestrictions allergenRestrictions)
    {
        NutritionPreferences = nutritionPreferences;
        IngredientPreferences = ingredientPreferences;
        AllergenRestrictions = allergenRestrictions;
    }

    public static FoodPreferences Create()
    {
        return new FoodPreferences(
            NutritionPreferences.Create(),
            IngredientPreferences.Create(),
            AllergenRestrictions.Create());
    }

    public FoodPreferences WithNutritionPreferences(NutritionPreferences nutritionPreferences)
    {
        return new FoodPreferences(nutritionPreferences, IngredientPreferences, AllergenRestrictions);
    }

    public FoodPreferences WithIngredientPreferences(IngredientPreferences ingredientPreferences)
    {
        return new FoodPreferences(NutritionPreferences, ingredientPreferences, AllergenRestrictions);
    }

    public FoodPreferences WithAllergenRestrictions(AllergenRestrictions allergenRestrictions)
    {
        return new FoodPreferences(NutritionPreferences, IngredientPreferences, allergenRestrictions);
    }
}