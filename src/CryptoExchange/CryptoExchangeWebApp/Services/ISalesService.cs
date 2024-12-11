using CryptoExchange.Common.Dtos;

namespace CryptoExchange.WebApp.Services;

/// <summary>
/// Represents wrapper for exchange service and trading service.
/// </summary>
public interface ISalesService
{
	ICollection<OrderDto> Buy(int numberOfBtc);

	ICollection<OrderDto> Sell(int numberOfBtc);
}