using CryptoExchange.Common.Models;
using CryptoExchange.Common.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace CryptoExchange.Common.Tests.Services
{
	public class OrderServiceTests
	{
		private OrderService _systemUnderTest;
		private readonly List<Exchange> _exchanges =
		[
			new Exchange
			{
				OrderBook = new OrderBook
				{
					Asks = new List<OrderWrapper>
					{
						new(), new(), new()
					},
					Bids = new List<OrderWrapper>
					{
						new(), new()
					}
				}
			},

			new Exchange
			{
				OrderBook = new OrderBook
				{
					Asks = new List<OrderWrapper>
					{
						new(), new(), new()
					},
					Bids = new List<OrderWrapper>
					{
						new(), new()
					}
				}
			}
		];

		[SetUp]
		public void SetUp()
		{
			_systemUnderTest = Substitute.ForPartsOf<OrderService>();
		}

		[Test]
		public void GetAllBuyOrders_ExchangeDataProvided_ReturnsListOfObjects()
		{
			var result = _systemUnderTest.GetAllBuyOrders(_exchanges);
			result.Should().NotBeEmpty();
			result.Should().HaveCount(2);
			foreach (var key in result.Keys)
			{
				result[key].Should().HaveCount(2);
			}
		}

		[Test]
		public void GetAllSellOrders_ExchangeDataProvided_ReturnsListOfObjects()
		{
			var result = _systemUnderTest.GetAllSellOrders(_exchanges);
			result.Should().NotBeEmpty();
			result.Should().HaveCount(2);
			foreach (var key in result.Keys)
			{
				result[key].Should().HaveCount(3);
			}
		}

	}
}
