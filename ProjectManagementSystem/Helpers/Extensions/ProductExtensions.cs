using System.Text.Json;
using ProjectManagementSystem.DTOs;
using ProjectManagementSystem.Entities;

namespace ProjectManagementSystem.Helpers.Extensions
{
    public static class ProductExtensions
    {
        public static ProductDetailDto ToDetailDto(this Product p) => new()
        {
            Id              = p.Id,
            Name            = p.Name,
            Description     = p.Description,
            Sku             = p.SKU,
            Price           = p.Price,
            DiscountedPrice = p.DiscountedPrice,
            Category        = new CategoryBasicDto { Id = p.Category?.Id ?? 0, Name = p.Category?.Name ?? "" },
            Supplier        = p.Supplier == null
                                ? null
                                : new SupplierBasicDto
                                {
                                    Id = p.Supplier.Id,
                                    Name = p.Supplier.Name,
                                    ContactEmail = p.Supplier.ContactEmail,
                                    Rating = p.Supplier.Rating
                                },
            IsActive        = p.IsActive,
            IsFeatured      = p.IsFeatured,
            AverageRating   = p.AverageRating,
            ReviewCount     = p.ReviewCount,
            ImageUrl        = p.ImageUrl,
            Tags            = string.IsNullOrEmpty(p.Tags)
                                  ? new()
                                  : JsonSerializer.Deserialize<List<string>>(p.Tags) ?? new(),
            Specifications  = string.IsNullOrEmpty(p.Specifications)
                                  ? new()
                                  : JsonSerializer.Deserialize<Dictionary<string, string>>(p.Specifications) ?? new(),
            Inventory       = p.Inventory?.ToStatusDto(),
            Attributes      = p.Attributes.Select(a => a.ToDto()).ToList(),
            RecentReviews   = p.Reviews
                                .Where(r => r.IsApproved)
                                .OrderByDescending(r => r.CreatedAt)
                                .Take(5)
                                .Select(r => r.ToDto())
                                .ToList()
        };

        public static ProductSummaryDto ToSummaryDto(this Product p) => new()
        {
            Id              = p.Id,
            Name            = p.Name,
            // Truncate description to 100 chars for list views
            Description     = p.Description?.Length > 100
                                  ? p.Description[..100] + "..." : p.Description ?? "",
            Price           = p.Price,
            DiscountedPrice = p.DiscountedPrice,
            ImageUrl        = p.ImageUrl,
            CategoryName    = p.Category?.Name ?? "",
            AverageRating   = p.AverageRating,
            ReviewCount     = p.ReviewCount,
            IsInStock       = p.Inventory?.StockQuantity > 0
        };

        public static ProductReviewDto ToDto(this ProductReview r) => new()
        {
            Id           = r.Id,
            ReviewerName = r.ReviewerName,
            Rating       = r.Rating,
            Comment      = r.Comment,
            CreatedAt    = r.CreatedAt
        };

        public static ProductAttributeDto ToDto(this ProductAttribute a) => new()
        {
            AttributeName  = a.AttributeName,
            AttributeValue = a.AttributeValue
        };

        public static InventoryStatusDto ToStatusDto(this Inventory i) => new()
        {
            StockQuantity     = i.StockQuantity,
            ReorderLevel      = i.ReorderLevel,
            WarehouseLocation = i.WarehouseLocation,
            LastUpdated       = i.LastUpdated
        };
    }
}
