using Nuta.Backend.Products.Domain.Aggregates;

namespace Nuta.Backend.Products.Application.Services.Interfaces;

public interface IProductAssessmentService
{
    Task<int> CalculateNutaScoreAsync(Product product, CancellationToken cancellationToken);
}