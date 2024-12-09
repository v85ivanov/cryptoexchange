namespace Common.Models
{
	/// <summary>
	/// Represents the order book model.
	/// </summary>
	public class OrderBook
	{
		public ICollection<Order> Bids { get; set; }

		public ICollection<Order> Asks { get; set; }
	}
}
