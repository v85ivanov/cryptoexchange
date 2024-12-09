using Common.Models;

namespace Common.Services
{
	internal class OrderService : IOrderService
	{
		public ICollection<Order> GetAllBuyOrders(ICollection<Exchange> exchanges)
		{
			var result = new List<Order>();

			foreach (var exchange in exchanges)
			{
				result.AddRange(exchange.OrderBook.Bids);
			}

			return result;
		}

		public ICollection<Order> GetAllSellOrders(ICollection<Exchange> exchanges)
		{
			var result = new List<Order>();

			foreach (var exchange in exchanges)
			{
				result.AddRange(exchange.OrderBook.Asks);
			}

			return result;
		}
	}
}
