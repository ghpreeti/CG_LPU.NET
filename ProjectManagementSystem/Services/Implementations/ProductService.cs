using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.DTOs;
using ProjectManagementSystem.Entities;
using ProjectManagementSystem.Helpers.Extensions;
using ProjectManagementSystem.Helpers.QueryObjects;
using ProjectManagementSystem.Services.Interfaces;

namespace ProjectManagementSystem.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ProductQuery _productQuery;
        private readonly ILogger<ProductService> _logger;

        public ProductService(
            AppDbContext context,
            IMapper mapper,
            ProductQuery productQuery,
            ILogger<ProductService> logger)
        {
            _context = context;
            _mapper = mapper;
            _productQuery = productQuery;
            _logger = logger;
        }

        public async Task<PagedResultDto<ProductSummaryDto>> GetAllProductsAsync(ProductFilterDto filter, int page = 1, int size = 10)
        {
            page = Math.Max(1, page);
            size = Math.Max(1, size);

            var query = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Inventory)
                .AsNoTracking();

            query = _productQuery.ApplyFilter(query, filter);

            var total = await query.CountAsync();

            query = _productQuery.ApplySorting(query, filter?.SortBy, filter?.SortDescending ?? false);
            var products = await _productQuery
                .ApplyPagination(query, page, size)
                .ToListAsync();

            return new PagedResultDto<ProductSummaryDto>
            {
                Items = products.Select(p => p.ToSummaryDto()).ToList(),
                TotalCount = total,
                PageNumber = page,
                PageSize = size,
                TotalPages = (int)Math.Ceiling(total / (double)size)
            };
        }

        public async Task<ProductDetailDto> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Include(p => p.Inventory)
                .Include(p => p.Reviews)
                .Include(p => p.Attributes)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                throw new KeyNotFoundException($"Product {id} not found");

            return product.ToDetailDto();
        }

        public async Task<ProductDetailDto> CreateProductAsync(CreateProductDto dto)
        {
            if (!await IsSkuUniqueAsync(dto.Sku))
                throw new InvalidOperationException($"SKU '{dto.Sku}' already exists");

            if (await _context.Categories.FindAsync(dto.CategoryId) == null)
                throw new KeyNotFoundException($"Category {dto.CategoryId} not found");

            var product = _mapper.Map<Product>(dto);
            product.CreatedAt = DateTime.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            _context.Inventories.Add(new Inventory
            {
                ProductId = product.Id,
                StockQuantity = 0,
                ReorderLevel = 10,
                WarehouseLocation = "Main Warehouse",
                LastUpdated = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();

            _logger.LogInformation("Product created: {Name} ({Sku})", product.Name, product.SKU);

            return await GetProductByIdAsync(product.Id);
        }

        public async Task<ProductDetailDto> UpdateProductAsync(int id, UpdateProductDto dto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                throw new KeyNotFoundException($"Product {id} not found");

            if (dto.CategoryId.HasValue && await _context.Categories.FindAsync(dto.CategoryId.Value) == null)
                throw new KeyNotFoundException($"Category {dto.CategoryId.Value} not found");

            var effectivePrice = dto.Price ?? product.Price;
            var effectiveDiscount = dto.DiscountedPrice ?? product.DiscountedPrice;
            if (effectiveDiscount.HasValue && effectiveDiscount.Value >= effectivePrice)
                throw new InvalidOperationException("Discounted price must be less than regular price");

            _mapper.Map(dto, product);
            await _context.SaveChangesAsync();

            return await GetProductByIdAsync(id);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return false;

            product.IsActive = false;
            product.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductSummaryDto>> GetFeaturedProductsAsync(int count = 10)
        {
            count = Math.Max(1, count);

            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Inventory)
                .AsNoTracking()
                .Where(p => p.IsActive && p.IsFeatured)
                .OrderByDescending(p => p.AverageRating)
                .ThenBy(p => p.Name)
                .Take(count)
                .ToListAsync();

            return products.Select(p => p.ToSummaryDto()).ToList();
        }

        public async Task<List<ProductSummaryDto>> GetBestSellingProductsAsync(int count = 10)
        {
            count = Math.Max(1, count);

            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Inventory)
                .AsNoTracking()
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.SoldCount)
                .ThenByDescending(p => p.AverageRating)
                .Take(count)
                .ToListAsync();

            return products.Select(p => p.ToSummaryDto()).ToList();
        }

        public async Task<List<ProductSummaryDto>> GetNewArrivalsAsync(int days = 30, int count = 10)
        {
            days = Math.Max(1, days);
            count = Math.Max(1, count);
            var cutoff = DateTime.UtcNow.AddDays(-days);

            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Inventory)
                .AsNoTracking()
                .Where(p => p.IsActive && p.CreatedAt >= cutoff)
                .OrderByDescending(p => p.CreatedAt)
                .Take(count)
                .ToListAsync();

            return products.Select(p => p.ToSummaryDto()).ToList();
        }

        public async Task<List<ProductSummaryDto>> GetRelatedProductsAsync(int productId, int count = 5)
        {
            count = Math.Max(1, count);

            var product = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
                throw new KeyNotFoundException($"Product {productId} not found");

            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Inventory)
                .AsNoTracking()
                .Where(p => p.IsActive && p.Id != productId && p.CategoryId == product.CategoryId)
                .OrderByDescending(p => p.AverageRating)
                .Take(count)
                .ToListAsync();

            return products.Select(p => p.ToSummaryDto()).ToList();
        }

        public async Task<InventoryStatusDto> GetProductInventoryAsync(int productId)
        {
            var inventory = await _context.Inventories
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.ProductId == productId);

            if (inventory == null)
                throw new KeyNotFoundException($"Inventory for product {productId} not found");

            return inventory.ToStatusDto();
        }

        public async Task<bool> UpdateInventoryAsync(int id, UpdateInventoryDto dto)
        {
            if (id != dto.ProductId)
                return false;

            var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.ProductId == id);
            if (inventory == null) return false;

            inventory.StockQuantity = dto.Quantity;
            inventory.LastUpdated = DateTime.UtcNow;

            _context.InventoryTransactions.Add(new InventoryTransaction
            {
                InventoryId = inventory.Id,
                Quantity = dto.Quantity,
                TransactionType = "Adjustment",
                TransactionDate = DateTime.UtcNow,
                Notes = dto.Notes ?? "Inventory update"
            });

            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> IsSkuUniqueAsync(string sku, int? excludeId = null)
        {
            return _context.Products
                .AsNoTracking()
                .Where(p => excludeId == null || p.Id != excludeId.Value)
                .AllAsync(p => p.SKU != sku);
        }

        public async Task<bool> IsProductAvailableAsync(int productId, int quantity)
        {
            if (quantity <= 0) return false;

            var inventory = await _context.Inventories
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.ProductId == productId);

            return inventory != null && inventory.StockQuantity >= quantity;
        }
    }
}
