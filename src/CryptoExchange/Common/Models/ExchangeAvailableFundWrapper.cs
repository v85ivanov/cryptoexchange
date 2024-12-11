namespace CryptoExchange.Common.Models;

/// <summary>
/// Represents the exchange and available funds wrapper.
/// </summary>
public class ExchangeAvailableFundWrapper
{
	public string ExchangeId { get; set; }

	public decimal AvailableCrypto { get; set; }
}