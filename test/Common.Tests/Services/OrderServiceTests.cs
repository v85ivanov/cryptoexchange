using Common.Models;
using Common.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Common.Tests.Services
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
			result.Should().HaveCount(4);
		}

		[Test]
		public void GetAllSellOrders_ExchangeDataProvided_ReturnsListOfObjects()
		{
			var result = _systemUnderTest.GetAllSellOrders(_exchanges);
			result.Should().NotBeEmpty();
			result.Should().HaveCount(6);
		}

	}
}
