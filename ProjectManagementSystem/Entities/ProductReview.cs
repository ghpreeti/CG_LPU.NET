namespace ProjectManagementSystem.Entities
{
    public class ProductReview
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ReviewerName { get; set; } = string.Empty;

        public int Rating { get; set; }

        public string Comment { get; set; } = string.Empty;

        public bool IsApproved { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation
        public virtual Product? Product { get; set; }
    }
}
