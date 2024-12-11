using System.Text.Json.Serialization;
using CryptoExchange.Common.Enums;

namespace CryptoExchange.Common.Models
{
	/// <summary>
	/// Represents the order model.
	/// </summary>
	public class Order
	{
		public Guid Id { get; set; }

		public DateTime Time { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public OrderType Type { get; set; }

		public string Kind { get; set; }

		public decimal Amount { get; set; }

		public decimal Price { get; set; }
	}
}
