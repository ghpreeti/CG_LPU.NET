namespace ProjectManagementSystem.Entities
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ContactEmail { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public double Rating { get; set; }

        public string PaymentTerms { get; set; } = string.Empty;

        // Navigation
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
