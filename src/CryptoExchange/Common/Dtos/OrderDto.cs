namespace CryptoExchange.Common.Dtos
{
	/// <summary>
	/// Represents the order dto.
	/// </summary>
	public class OrderDto
	{
		public string ExchangeId { get; set; } 

		public Guid Id { get; set; }

		public decimal Amount { get; set; }

		public decimal Price { get; set; }
	}
}
