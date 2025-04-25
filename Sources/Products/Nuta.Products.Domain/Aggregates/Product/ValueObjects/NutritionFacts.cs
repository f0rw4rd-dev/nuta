using Nuta.BuildingBlocks.Domain;

namespace Nuta.Products.Domain.Aggregates.Product.ValueObjects;

public class NutritionFacts : ValueObject
{
    public float? Calories { get; }

    public float? Protein { get; }

    public float? Fat { get; }

    public float? SaturatedFat { get; }

    public float? TransFat { get; }

    public float? Carbohydrates { get; }

    public float? Sugars { get; }

    public float? Fiber { get; }

    public float? Cholesterol { get; }

    public float? Sodium { get; }

    public float? Alcohol { get; }

    public float? Water { get; }

    public float? ServingSize { get; }

    public float? NetWeight { get; }
    
    private NutritionFacts()
    {
    }

    private NutritionFacts(
        float? calories = null,
        float? protein = null,
        float? fat = null,
        float? saturatedFat = null,
        float? transFat = null,
        float? carbohydrates = null,
        float? sugars = null,
        float? fiber = null,
        float? cholesterol = null,
        float? sodium = null,
        float? alcohol = null,
        float? water = null,
        float? servingSize = null,
        float? netWeight = null)
    {
        Calories = calories;
        Protein = protein;
        Fat = fat;
        SaturatedFat = saturatedFat;
        TransFat = transFat;
        Carbohydrates = carbohydrates;
        Sugars = sugars;
        Fiber = fiber;
        Cholesterol = cholesterol;
        Sodium = sodium;
        Alcohol = alcohol;
        Water = water;
        ServingSize = servingSize;
        NetWeight = netWeight;
    }

    public static NutritionFacts Create(
        float? calories = null,
        float? protein = null,
        float? fat = null,
        float? saturatedFat = null,
        float? transFat = null,
        float? carbohydrates = null,
        float? sugars = null,
        float? fiber = null,
        float? cholesterol = null,
        float? sodium = null,
        float? alcohol = null,
        float? water = null,
        float? servingSize = null,
        float? netWeight = null)
    {
        return new NutritionFacts(
            calories,
            protein,
            fat,
            saturatedFat,
            transFat,
            carbohydrates,
            sugars,
            fiber,
            cholesterol,
            sodium,
            alcohol,
            water,
            servingSize,
            netWeight);
    }
}