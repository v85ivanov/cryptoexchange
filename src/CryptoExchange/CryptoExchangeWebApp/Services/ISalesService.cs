using CryptoExchange.Common.Models;

namespace CryptoExchange.WebApp.Services;

/// <summary>
/// Represents wrapper for exchange service and trading service.
/// </summary>
public interface ISalesService
{
	ICollection<Order> Buy(int numberOfBtc);

	ICollection<Order> Sell(int numberOfBtc);
}