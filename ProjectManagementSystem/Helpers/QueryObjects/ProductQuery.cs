using ProjectManagementSystem.DTOs;
using ProjectManagementSystem.Entities;

namespace ProjectManagementSystem.Helpers.QueryObjects
{
    public class ProductQuery
    {
        public IQueryable<Product> ApplyFilter(
            IQueryable<Product> query, ProductFilterDto filter)
        {
            if (filter == null) return query;

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                var term = filter.SearchTerm.ToLower();
                query = query.Where(p =>
                    p.Name.ToLower().Contains(term) ||
                    p.Description.ToLower().Contains(term) ||
                    p.SKU.ToLower().Contains(term));
            }

            if (filter.CategoryId.HasValue)
            {
                var categoryId = filter.CategoryId.Value;
                query = query.Where(p => p.CategoryId == categoryId ||
                                         (p.Category != null && p.Category.ParentCategoryId == categoryId));
            }

            if (filter.CategoryIds is { Count: > 0 })
                query = query.Where(p => filter.CategoryIds.Contains(p.CategoryId));

            if (filter.MinPrice.HasValue)
                query = query.Where(p => p.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= filter.MaxPrice.Value);

            if (filter.IsOnSale == true)
                query = query.Where(p => p.DiscountedPrice != null
                                         && p.DiscountedPrice < p.Price);

            if (filter.IsFeatured.HasValue)
                query = query.Where(p => p.IsFeatured == filter.IsFeatured.Value);

            if (filter.MinRating.HasValue)
                query = query.Where(p => p.AverageRating >= filter.MinRating.Value);

            if (filter.InStock == true)
                query = query.Where(p => p.Inventory != null
                                         && p.Inventory.StockQuantity > 0);

            return query;
        }

        public IQueryable<Product> ApplySorting(
            IQueryable<Product> query, string? sortBy, bool desc = false)
            => sortBy?.ToLower() switch
            {
                "price"   => desc ? query.OrderByDescending(p => p.Price)   : query.OrderBy(p => p.Price),
                "name"    => desc ? query.OrderByDescending(p => p.Name)    : query.OrderBy(p => p.Name),
                "rating"  => query.OrderByDescending(p => p.AverageRating),
                "newest"  => query.OrderByDescending(p => p.CreatedAt),
                "popular" => query.OrderByDescending(p => p.SoldCount),
                _         => query.OrderBy(p => p.Name)
            };

        public IQueryable<Product> ApplyPagination(
            IQueryable<Product> query, int page, int size)
            => query.Skip((page - 1) * size).Take(size);
    }
}
