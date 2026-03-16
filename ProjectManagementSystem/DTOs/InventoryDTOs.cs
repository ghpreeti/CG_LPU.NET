namespace ProjectManagementSystem.DTOs
{
    public class InventoryStatusDto
    {
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public string WarehouseLocation { get; set; } = string.Empty;
        public bool IsInStock => StockQuantity > 0;
        public bool IsLowStock => StockQuantity > 0 && StockQuantity <= ReorderLevel;
        public DateTime LastUpdated { get; set; }
    }

    public class UpdateInventoryDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Notes { get; set; }
    }
}
