namespace Common.Models
{
	/// <summary>
	/// Represents the order book model.
	/// </summary>
	public class OrderBook
	{
		public ICollection<OrderWrapper> Bids { get; set; }

		public ICollection<OrderWrapper> Asks { get; set; }
	}
}
