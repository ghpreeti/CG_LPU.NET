namespace ProjectManagementSystem.Entities
{
    public class InventoryTransaction
    {
        public int Id { get; set; }

        public int InventoryId { get; set; }

        public int Quantity { get; set; }

        public string TransactionType { get; set; } = string.Empty;
        // Purchase, Sale, Adjustment

        public DateTime TransactionDate { get; set; }

        public string Notes { get; set; } = string.Empty;

        // Navigation
        public virtual Inventory? Inventory { get; set; }
    }
}
