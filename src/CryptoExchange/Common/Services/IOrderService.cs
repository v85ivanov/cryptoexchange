using CryptoExchange.Common.Models;

namespace CryptoExchange.Common.Services
{
	/// <summary>
	/// Represents the order service.
	/// </summary>
	public interface IOrderService
	{
		/// <summary>
		/// Gets all buy orders from all exchanges.
		/// </summary>
		/// <param name="exchanges"></param>
		/// <returns></returns>
		Dictionary<ExchangeAvailableFundWrapper, IOrderedEnumerable<Order>> GetAllBuyOrders(ICollection<Exchange> exchanges);

		/// <summary>
		/// Gets all sell orders from all exchanges.
		/// </summary>
		/// <param name="exchanges"></param>
		/// <returns></returns>
		Dictionary<ExchangeAvailableFundWrapper, IOrderedEnumerable<Order>> GetAllSellOrders(ICollection<Exchange> exchanges);
	}
}
