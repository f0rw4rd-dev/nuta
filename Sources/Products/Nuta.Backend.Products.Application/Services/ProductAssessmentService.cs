using Nuta.Backend.Products.Application.Services.Interfaces;
using Nuta.Backend.Products.Application.Utilities;
using Nuta.Backend.Products.Domain.Aggregates;
using Nuta.Backend.Products.Domain.Enums;
using Nuta.Backend.Products.Domain.Repositories;
using Nuta.Backend.Products.Domain.ValueObjects;

namespace Nuta.Backend.Products.Application.Services;

public class ProductAssessmentService(IAdditiveRepository additiveRepository) : IProductAssessmentService
{
    // Веса
    private const double NutrientWeight = 0.60;
    private const double AdditiveWeight = 0.40;

    // Дополнительные бонусы/штрафы
    private const int RussianQualityMarkBonus = 15;

    // Шкала пищевой и энергетической ценностей (доля ккал)
    private const double ProteinLow = 0.20;
    private const double ProteinHigh = 0.35;

    private const double FatLow = 0.20;
    private const double FatHigh = 0.35;

    private const double CarbLow = 0.45;
    private const double CarbHigh = 0.60;

    private const double CaloriesLow = 150;
    private const double CaloriesHigh = 600;

    private const int MacroMaxScore = 25;
    private const int CaloriesMaxScore = 25;

    public async Task<int> CalculateNutaScoreAsync(Product product, CancellationToken cancellationToken)
    {
        var additives = await additiveRepository.GetListByIdsAsync(
            product.Ingredients.AdditiveIds,
            cancellationToken);

        var nutrientScore = CalculateNutrientScore(product.NutritionFacts);
        var additiveScore = CalculateAdditiveScore(additives);

        var weighted = NutrientWeight * nutrientScore + AdditiveWeight * additiveScore;

        if (product.Labels is { HasRussianQualityMark: true })
            weighted += RussianQualityMarkBonus;

        return Math.Clamp((int)Math.Round(weighted), 0, 100);
    }

    private static double CalculateNutrientScore(NutritionFacts facts)
    {
        var proteinKcal = facts.Protein * 4;
        var fatKcal = facts.Fat * 9;
        var carbKcal = facts.Carbohydrates * 4;

        var proteinScore = MathHelper.LinearScore(proteinKcal, ProteinLow, ProteinHigh, MacroMaxScore);
        var fatScore = MathHelper.LinearScore(fatKcal, FatLow, FatHigh, MacroMaxScore);
        var carbScore = MathHelper.LinearScore(carbKcal, CarbLow, CarbHigh, MacroMaxScore);

        var caloriesScore = facts.Calories switch
        {
            <= CaloriesMaxScore
                => CaloriesMaxScore,
            > CaloriesMaxScore and <= CaloriesHigh
                => MacroMaxScore * (1 - (facts.Calories - CaloriesLow) / (CaloriesHigh - CaloriesLow)),
            _ => 0
        };

        return proteinScore + fatScore + carbScore + caloriesScore;
    }

    private static int CalculateAdditiveScore(IReadOnlyCollection<Additive> additives)
    {
        var score = 100;

        foreach (var additive in additives)
        {
            score -= additive.RiskLevel switch
            {
                AdditiveRiskLevel.LimitedRisk => 15,
                AdditiveRiskLevel.ModerateRisk => 30,
                AdditiveRiskLevel.HighRisk => 40,
                _ => 0
            };
        }

        return Math.Max(score, 0);
    }
}