namespace order_project.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public int Id { get; set; }

        public int? Sl { get; set; }

        public string? OrderDesc { get; set; }

        [Required(ErrorMessage = "Select your Product.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Select your Customer.")]
        public int CustomerId { get; set; }

        public string? ProductName { get; set; }

        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        public decimal OrderAmount { get; set; }

        public DateTime? OrderDt { get; set; }
    }

}
