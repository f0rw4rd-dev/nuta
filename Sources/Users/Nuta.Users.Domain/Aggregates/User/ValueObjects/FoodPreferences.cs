using Nuta.BuildingBlocks.Domain;

namespace Nuta.Users.Domain.Aggregates.User.ValueObjects;

public class FoodPreferences : ValueObject
{
    public NutritionPreferences NutritionPreferences { get; }

    public IngredientPreferences IngredientPreferences { get; }

    public AllergenRestrictions AllergenRestrictions { get; }
    
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