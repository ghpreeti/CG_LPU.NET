using System.Text.Json;
using ProjectManagementSystem.Entities;

namespace ProjectManagementSystem.Data
{
    public static class SeedData
    {
        private static readonly JsonSerializerOptions _json = new();

        public static async Task InitializeAsync(AppDbContext context)
        {
            if (context.Categories.Any()) return;  // Already seeded

            // ── Parent Categories ──────────────────────────────────────────
            var electronics = new Category { Name = "Electronics", CreatedAt = DateTime.UtcNow };
            var clothing    = new Category { Name = "Clothing",    CreatedAt = DateTime.UtcNow };
            var books       = new Category { Name = "Books",       CreatedAt = DateTime.UtcNow };

            context.Categories.AddRange(electronics, clothing, books);
            await context.SaveChangesAsync();

            // ── Sub-Categories ─────────────────────────────────────────────
            var laptops  = new Category { Name = "Laptops",       ParentCategoryId = electronics.Id, CreatedAt = DateTime.UtcNow };
            var phones   = new Category { Name = "Smartphones",   ParentCategoryId = electronics.Id, CreatedAt = DateTime.UtcNow };
            var mensWear = new Category { Name = "Men's Clothing", ParentCategoryId = clothing.Id,    CreatedAt = DateTime.UtcNow };
            var fiction  = new Category { Name = "Fiction",        ParentCategoryId = books.Id,       CreatedAt = DateTime.UtcNow };

            context.Categories.AddRange(laptops, phones, mensWear, fiction);
            await context.SaveChangesAsync();

            // ── Suppliers ──────────────────────────────────────────────────
            var techCorp = new Supplier
            {
                Name         = "TechCorp Ltd",
                ContactEmail = "supply@techcorp.com",
                Phone        = "555-0101",
                Address      = "123 Tech Ave, Silicon Valley",
                Rating       = 4.8,
                PaymentTerms = "Net 30"
            };
            var fashionHub = new Supplier
            {
                Name         = "FashionHub Inc",
                ContactEmail = "orders@fashionhub.com",
                Phone        = "555-0202",
                Address      = "456 Fashion St, New York",
                Rating       = 4.5,
                PaymentTerms = "Net 15"
            };

            context.Suppliers.AddRange(techCorp, fashionHub);
            await context.SaveChangesAsync();

            // ── Products ───────────────────────────────────────────────────
            var laptop = new Product
            {
                Name            = "Laptop Pro 15",
                Description     = "High-performance laptop with 15-inch display, Intel Core i7, 16GB RAM, 512GB SSD.",
                Price           = 1299.99m,
                DiscountedPrice = 1149.99m,
                CategoryId      = laptops.Id,
                SupplierId      = techCorp.Id,
                SKU             = "LTPRO-15-I7",
                IsActive        = true,
                IsFeatured      = true,
                CreatedAt       = DateTime.UtcNow,
                AverageRating   = 4.7,
                ReviewCount     = 2,
                ImageUrl        = "https://example.com/images/laptop-pro-15.jpg",
                Tags            = JsonSerializer.Serialize(new[] { "laptop", "electronics", "featured" }, _json),
                Specifications  = JsonSerializer.Serialize(new Dictionary<string, string>
                {
                    ["Processor"] = "Intel Core i7-1260P",
                    ["RAM"]       = "16GB DDR5",
                    ["Storage"]   = "512GB NVMe SSD",
                    ["Display"]   = "15.6\" FHD IPS",
                    ["Battery"]   = "72Wh, up to 12h"
                }, _json)
            };

            var phone = new Product
            {
                Name            = "UltraPhone X",
                Description     = "Flagship smartphone with 6.7-inch AMOLED display, 50MP camera, 5G ready.",
                Price           = 899.99m,
                DiscountedPrice = null,
                CategoryId      = phones.Id,
                SupplierId      = techCorp.Id,
                SKU             = "UPHX-5G-128",
                IsActive        = true,
                IsFeatured      = true,
                CreatedAt       = DateTime.UtcNow,
                AverageRating   = 4.5,
                ReviewCount     = 2,
                ImageUrl        = "https://example.com/images/ultraphone-x.jpg",
                Tags            = JsonSerializer.Serialize(new[] { "phone", "5g", "flagship" }, _json),
                Specifications  = JsonSerializer.Serialize(new Dictionary<string, string>
                {
                    ["Display"] = "6.7\" AMOLED 120Hz",
                    ["Camera"]  = "50MP + 12MP + 10MP",
                    ["Battery"] = "5000mAh",
                    ["Storage"] = "128GB",
                    ["OS"]      = "Android 14"
                }, _json)
            };

            var shirt = new Product
            {
                Name            = "Classic Oxford Shirt",
                Description     = "Premium cotton Oxford shirt, available in multiple colors, perfect for business casual.",
                Price           = 59.99m,
                DiscountedPrice = 44.99m,
                CategoryId      = mensWear.Id,
                SupplierId      = fashionHub.Id,
                SKU             = "SHRT-OXF-M-WHT",
                IsActive        = true,
                IsFeatured      = false,
                CreatedAt       = DateTime.UtcNow,
                AverageRating   = 4.3,
                ReviewCount     = 2,
                ImageUrl        = "https://example.com/images/oxford-shirt.jpg",
                Tags            = JsonSerializer.Serialize(new[] { "shirt", "clothing", "formal" }, _json),
                Specifications  = JsonSerializer.Serialize(new Dictionary<string, string>
                {
                    ["Material"] = "100% Cotton",
                    ["Fit"]      = "Regular Fit",
                    ["Collar"]   = "Oxford Button-Down",
                    ["Care"]     = "Machine Washable"
                }, _json)
            };

            context.Products.AddRange(laptop, phone, shirt);
            await context.SaveChangesAsync();

            // ── Inventory ──────────────────────────────────────────────────
            context.Inventories.AddRange(
                new Inventory { ProductId = laptop.Id, StockQuantity = 45,  ReorderLevel = 10, WarehouseLocation = "Rack A1",  LastUpdated = DateTime.UtcNow },
                new Inventory { ProductId = phone.Id,  StockQuantity = 120, ReorderLevel = 20, WarehouseLocation = "Rack B3",  LastUpdated = DateTime.UtcNow },
                new Inventory { ProductId = shirt.Id,  StockQuantity = 8,   ReorderLevel = 15, WarehouseLocation = "Shelf C2", LastUpdated = DateTime.UtcNow }
            );
            await context.SaveChangesAsync();

            // ── Product Attributes ─────────────────────────────────────────
            context.ProductAttributes.AddRange(
                new ProductAttribute { ProductId = laptop.Id, AttributeName = "Color",        AttributeValue = "Space Gray" },
                new ProductAttribute { ProductId = laptop.Id, AttributeName = "Warranty",     AttributeValue = "2 Years" },
                new ProductAttribute { ProductId = phone.Id,  AttributeName = "Color",        AttributeValue = "Midnight Black" },
                new ProductAttribute { ProductId = phone.Id,  AttributeName = "Network",      AttributeValue = "5G" },
                new ProductAttribute { ProductId = shirt.Id,  AttributeName = "Color",        AttributeValue = "White" },
                new ProductAttribute { ProductId = shirt.Id,  AttributeName = "Size Options", AttributeValue = "S, M, L, XL, XXL" }
            );
            await context.SaveChangesAsync();

            // ── Product Reviews ────────────────────────────────────────────
            context.ProductReviews.AddRange(
                new ProductReview { ProductId = laptop.Id, ReviewerName = "Alice Johnson", Rating = 5, Comment = "Excellent performance, battery life is outstanding.",  IsApproved = true, CreatedAt = DateTime.UtcNow.AddDays(-10) },
                new ProductReview { ProductId = laptop.Id, ReviewerName = "Bob Martinez",  Rating = 4, Comment = "Great laptop, slightly heavy but worth the price.",     IsApproved = true, CreatedAt = DateTime.UtcNow.AddDays(-5)  },
                new ProductReview { ProductId = phone.Id,  ReviewerName = "Carol White",   Rating = 5, Comment = "Best camera I've used on a phone. Incredible display.", IsApproved = true, CreatedAt = DateTime.UtcNow.AddDays(-8)  },
                new ProductReview { ProductId = phone.Id,  ReviewerName = "David Kim",     Rating = 4, Comment = "Fast and smooth, the 120Hz display is buttery.",        IsApproved = true, CreatedAt = DateTime.UtcNow.AddDays(-3)  },
                new ProductReview { ProductId = shirt.Id,  ReviewerName = "Emma Clarke",   Rating = 4, Comment = "Great quality fabric, fits true to size.",             IsApproved = true, CreatedAt = DateTime.UtcNow.AddDays(-6)  },
                new ProductReview { ProductId = shirt.Id,  ReviewerName = "Frank Nguyen",  Rating = 5, Comment = "Perfect for office wear, very comfortable.",           IsApproved = true, CreatedAt = DateTime.UtcNow.AddDays(-2)  }
            );
            await context.SaveChangesAsync();
        }
    }
}
