namespace order_project.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string OrderDesc { get; set; }

		public int ProductId { get; set; }

		public int CustomerId { get; set; }

		public int Quantity { get; set; }

		public decimal OrderAmount { get; set; }
		public DateTime OrderDt { get; set; }
	}
}
