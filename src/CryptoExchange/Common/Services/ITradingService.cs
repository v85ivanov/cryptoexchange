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
		ICollection<Order> Buy(ICollection<Exchange> exchangeData, int numberOfBtc);

		/// <summary>
		/// Sells BTC.
		/// </summary>
		/// <param name="exchangeData"></param>
		/// <param name="numberOfBtc"></param>
		/// <returns></returns>
		ICollection<Order> Sell(ICollection<Exchange> exchangeData, int numberOfBtc);
	}
}
