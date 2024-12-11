using CryptoExchange.Common.Dtos;
using CryptoExchange.Common.Models;

namespace CryptoExchange.Common.Services
{
	/// <summary>
	/// Represents the trading service.
	/// </summary>
	public interface ITradingService
	{
		/// <summary>
		/// Buys BTC.
		/// </summary>
		/// <param name="exchangeData"></param>
		/// <param name="numberOfBtc"></param>
		/// <returns></returns>
		ICollection<OrderDto> Buy(ICollection<Exchange> exchangeData, int numberOfBtc);

		/// <summary>
		/// Sells BTC.
		/// </summary>
		/// <param name="exchangeData"></param>
		/// <param name="numberOfBtc"></param>
		/// <returns></returns>
		ICollection<OrderDto> Sell(ICollection<Exchange> exchangeData, int numberOfBtc);
	}
}
