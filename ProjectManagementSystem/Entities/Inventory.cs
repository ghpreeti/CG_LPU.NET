namespace ProjectManagementSystem.Entities
{
    public class Inventory
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int StockQuantity { get; set; }

        public int ReorderLevel { get; set; }

        public string WarehouseLocation { get; set; } = string.Empty;

        public DateTime LastUpdated { get; set; }

        // Navigation
        public virtual Product? Product { get; set; }

        public virtual ICollection<InventoryTransaction> Transactions { get; set; } = new List<InventoryTransaction>();
    }

}
