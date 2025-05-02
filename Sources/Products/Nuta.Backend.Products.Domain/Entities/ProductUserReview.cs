using System.Diagnostics.CodeAnalysis;
using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.Entities;

public class ProductUserReview : Entity
{
    public Guid ProductId { get; }
    
    public Guid UserId { get; }
    
    public int Rating { get; private set; }
    
    public string? Comment { get; private set; }
    
    public bool IsHidden { get; private set; }
    
    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; private set; }
    
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    private ProductUserReview()
    {
        // EF Core
    }
    
    private ProductUserReview(Guid productId, Guid userId, int rating, string? comment)
    {
        ProductId = productId;
        UserId = userId;
        Rating = rating;
        Comment = comment;
        IsHidden = false;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public static ProductUserReview Create(Guid productId, Guid userId, int rating, string? comment)
    {
        return new ProductUserReview(productId, userId, rating, comment);
    }
    
    public void Hide()
    {
        IsHidden = true;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Unhide()
    {
        IsHidden = false;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Update(int rating, string? comment)
    {
        Rating = rating;
        Comment = comment;
        UpdatedAt = DateTime.UtcNow;
    }
}