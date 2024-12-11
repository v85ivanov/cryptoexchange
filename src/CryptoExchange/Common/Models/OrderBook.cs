namespace Common.Models
{
	/// <summary>
	/// Represents the order book model.
	/// </summary>
	public class OrderBook
	{
		public required ICollection<OrderWrapper> Bids { get; set; }

		public required ICollection<OrderWrapper> Asks { get; set; }
	}
}
