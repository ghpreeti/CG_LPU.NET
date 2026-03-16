using ProjectManagementSystem.Entities;

namespace ProjectManagementSystem.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public string SKU { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public bool IsFeatured { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Stored as JSON strings
        public string ImageUrl { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Specifications { get; set; } = string.Empty;

        // Internal metrics — should NOT appear in public API responses
        public int ViewCount { get; set; }
        public int SoldCount { get; set; }
        public double AverageRating { get; set; }
        public int ReviewCount { get; set; }

        // Navigation properties
        public virtual Category? Category { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual Inventory? Inventory { get; set; }
        public virtual ICollection<ProductReview> Reviews { get; set; } = new List<ProductReview>();
        public virtual ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
    }
}

