using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.DTOs;
using ProjectManagementSystem.Services.Interfaces;

namespace ProjectManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _svc;

        public ProductsController(IProductService svc) => _svc = svc;

        [HttpGet]
        [ProducesResponseType(typeof(PagedResultDto<ProductSummaryDto>), 200)]
        public async Task<ActionResult<PagedResultDto<ProductSummaryDto>>> GetAll(
            [FromQuery] ProductListQueryDto query,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var filter = new ProductFilterDto
            {
                SearchTerm = query.SearchTerm,
                CategoryId = query.CategoryId,
                MinPrice = query.MinPrice,
                MaxPrice = query.MaxPrice,
                IsOnSale = query.IsOnSale,
                InStock = query.InStock,
                SortBy = query.SortBy,
                SortDescending = query.SortDescending
            };

            return Ok(await _svc.GetAllProductsAsync(filter, pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDetailDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductDetailDto>> Get(int id)
        {
            try { return Ok(await _svc.GetProductByIdAsync(id)); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDetailDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ProductDetailDto>> Create([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var product = await _svc.CreateProductAsync(dto);
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
            catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
            catch (KeyNotFoundException ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductDetailDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ProductDetailDto>> Update(int id, [FromBody] UpdateProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try { return Ok(await _svc.UpdateProductAsync(id, dto)); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
            catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => (await _svc.DeleteProductAsync(id)) ? NoContent() : NotFound();

        [HttpPatch("{id}/soft-delete")]
        public async Task<IActionResult> SoftDelete(int id)
            => (await _svc.SoftDeleteProductAsync(id)) ? NoContent() : NotFound();

        [HttpGet("featured")]
        public async Task<ActionResult<List<ProductSummaryDto>>> GetFeatured([FromQuery] int count = 10)
            => Ok(await _svc.GetFeaturedProductsAsync(count));

        [HttpGet("{id}/inventory")]
        [ProducesResponseType(typeof(InventoryStatusDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<InventoryStatusDto>> GetInventory(int id)
        {
            try { return Ok(await _svc.GetProductInventoryAsync(id)); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
        }

        [HttpPut("{id}/inventory")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateInventory(int id, [FromBody] UpdateInventoryDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return (await _svc.UpdateInventoryAsync(id, dto)) ? NoContent() : NotFound();
        }
    }
}
