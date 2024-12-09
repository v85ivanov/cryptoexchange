namespace Common.Models
{
	/// <summary>
	/// Represents the exchange model.
	/// </summary>
	public class Exchange
	{
		public string Id { get; set; }

		public AvailableFund AvailableFunds { get; set; }

		public OrderBook OrderBook { get; set; }
	}
}
