using Common.Models;
using Microsoft.Extensions.Logging;

namespace Common.Services
{
	/// <summary>
	/// Implementation of <see cref="ITradingService"/>.
	/// </summary>
	/// <param name="orderService"></param>
	/// <param name="logger"></param>
	internal class TradingService(IOrderService orderService, ILogger<TradingService> logger)
		: ITradingService
	{
		public ICollection<Order>Buy(ICollection<Exchange> exchangeData, int numberOfBtc)
		{
			if (numberOfBtc == 0)
			{
				return new List<Order>();
			}
			logger.LogInformation("Buying {NumberOfBtc} BTC", numberOfBtc);
			var sortedOrders = orderService.GetAllBuyOrders(exchangeData).OrderBy(x => x.Price);
			return GetRequiredOrders(sortedOrders, numberOfBtc);
		}

		public ICollection<Order> Sell(ICollection<Exchange> exchangeData, int numberOfBtc)
		{
			if (numberOfBtc == 0)
			{
				return new List<Order>();
			}

			logger.LogInformation("Selling {NumberOfBtc} BTC", numberOfBtc);
			var sortedOrders = orderService.GetAllSellOrders(exchangeData).OrderByDescending(x => x.Price);
			return GetRequiredOrders(sortedOrders, numberOfBtc);

		}

		private IList<Order> GetRequiredOrders(IOrderedEnumerable<Order> sortedOrders, int numberOfBtc)
		{
			var result = new List<Order>();
			var currentAmount = decimal.Zero;
			foreach (var order in sortedOrders)
			{
				result.Add(order);
				currentAmount += order.Amount;
				if (currentAmount >= numberOfBtc)
				{
					break;
				}
			}

			return result;
		}
	}
}
