using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.ValueObjects;

public class NutritionFacts : ValueObject
{
    public double Calories { get; }

    public double Protein { get; }

    public double Fat { get; }

    public double Carbohydrates { get; }

    public double? SaturatedFat { get; }

    public double? TransFat { get; }

    public double? Sugars { get; }

    public double? Fiber { get; }

    public double? Cholesterol { get; }

    public double? Sodium { get; }

    public double? Alcohol { get; }

    public double? Water { get; }

    public double? ServingSize { get; }

    public double? NetWeight { get; }

    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private NutritionFacts()
    {
        // EF Core
    }

    private NutritionFacts(
        double calories,
        double protein,
        double fat,
        double carbohydrates,
        double? saturatedFat = null,
        double? transFat = null,
        double? sugars = null,
        double? fiber = null,
        double? cholesterol = null,
        double? sodium = null,
        double? alcohol = null,
        double? water = null,
        double? servingSize = null,
        double? netWeight = null)
    {
        Calories = calories;
        Protein = protein;
        Fat = fat;
        Carbohydrates = carbohydrates;
        SaturatedFat = saturatedFat;
        TransFat = transFat;
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
        double calories,
        double protein,
        double fat,
        double carbohydrates,
        double? saturatedFat = null,
        double? transFat = null,
        double? sugars = null,
        double? fiber = null,
        double? cholesterol = null,
        double? sodium = null,
        double? alcohol = null,
        double? water = null,
        double? servingSize = null,
        double? netWeight = null)
    {
        return new NutritionFacts(
            calories,
            protein,
            fat,
            carbohydrates,
            saturatedFat,
            transFat,
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