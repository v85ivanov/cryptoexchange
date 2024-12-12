using CryptoExchange.Common.Dtos;
using CryptoExchange.Common.Models;
using Microsoft.Extensions.Logging;

namespace CryptoExchange.Common.Services
{
	/// <summary>
	/// Implementation of <see cref="ITradingService"/>.
	/// </summary>
	/// <param name="orderService"></param>
	/// <param name="logger"></param>
	internal class TradingService(IOrderService orderService, ILogger<TradingService> logger)
		: ITradingService
	{
		public ICollection<OrderDto> Buy(ICollection<Exchange> exchangeData, int numberOfBtc)
		{
			if (numberOfBtc == 0)
			{
				return new List<OrderDto>();
			}
			logger.LogInformation("Buying {NumberOfBtc} BTC", numberOfBtc);
			return GetRequiredOrders(orderService.GetAllSellOrders(exchangeData), numberOfBtc);
		}

		public ICollection<OrderDto> Sell(ICollection<Exchange> exchangeData, int numberOfBtc)
		{
			if (numberOfBtc == 0)
			{
				return new List<OrderDto>();
			}

			logger.LogInformation("Selling {NumberOfBtc} BTC", numberOfBtc);
			return GetRequiredOrders(orderService.GetAllBuyOrders(exchangeData), numberOfBtc);

		}

		private IList<OrderDto> GetRequiredOrders(Dictionary<ExchangeAvailableFundWrapper, IOrderedEnumerable<Order>> sortedOrders, int numberOfBtc)
		{
			var result = new List<OrderDto>();
			var currentAmount = decimal.Zero;
			var keys = sortedOrders.Keys.OrderByDescending(x => x.AvailableCrypto);
			foreach (var key in keys)
			{
				var available = key.AvailableCrypto;
				var orders = sortedOrders[key];
				foreach (var order in orders)
				{
					result.Add(new OrderDto
					{
						ExchangeId = key.ExchangeId,
						Id = order.Id,
						Amount = order.Amount,
						Price = order.Price
					});
					currentAmount += order.Amount;
					available -= currentAmount;
					if (currentAmount >= numberOfBtc || available < decimal.Zero)
					{
						break;
					}
				}
				if (currentAmount >= numberOfBtc)
				{
					break;
				}
			}
			return result;
		}
	}
}
