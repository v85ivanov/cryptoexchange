using CryptoExchange.Common.Models;

namespace CryptoExchange.Common.Services
{
	/// <summary>
	/// Implementation of <see cref="IOrderService"/>.
	/// </summary>
	internal class OrderService : IOrderService
	{
		public Dictionary<ExchangeAvailableFundWrapper, IOrderedEnumerable<Order>> GetAllBuyOrders(ICollection<Exchange> exchanges)
		{
			return exchanges.ToDictionary(exchange => new ExchangeAvailableFundWrapper
				{
					ExchangeId = exchange.Id,
					AvailableCrypto = exchange.AvailableFunds?.Crypto ?? decimal.Zero
				},
				exchange => exchange.OrderBook.Bids.Select(x => x.Order).OrderByDescending(x => x.Price));
		}

		public Dictionary<ExchangeAvailableFundWrapper, IOrderedEnumerable<Order>> GetAllSellOrders(ICollection<Exchange> exchanges)
		{
			return exchanges.ToDictionary(exchange => new ExchangeAvailableFundWrapper
				{
					ExchangeId = exchange.Id,
					AvailableCrypto = exchange.AvailableFunds?.Crypto ?? decimal.Zero
			},
				exchange => exchange.OrderBook.Asks.Select(x => x.Order).OrderBy(x => x.Price));
		}
	}
}
