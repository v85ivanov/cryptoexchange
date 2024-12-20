﻿using CryptoExchange.Common.Models;
using CryptoExchange.Common.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;

namespace CryptoExchange.Common.Tests.Services
{
	public class TradingServiceTests
	{
		private TradingService _systemUnderTest;
		private IOrderService _orderService;

		[SetUp]
		public void SetUp()
		{
			_orderService = Substitute.For<IOrderService>();
			var logger = Substitute.For<ILogger<TradingService>>();

			_systemUnderTest = Substitute.ForPartsOf<TradingService>(_orderService, logger);
		}

		[Test]
		public void Buy_ExchangeDataProvided_ReturnsListOfOrders()
		{
			var data = new List<Exchange>();
			var dictionary = new Dictionary<ExchangeAvailableFundWrapper, IOrderedEnumerable<Order>>();
			var orderList = new List<Order>
			{
				new ()
				{
					Amount = 0.5m,
					Price = 70000
				},
				new ()
				{
					Amount = 0.5m,
					Price = 50000
				},
				new ()
				{
					Amount = 0.5m,
					Price = 60000
				},
				new ()
				{
					Amount = 0.5m,
					Price = 50001
				}
			}.OrderBy(x => x.Price);
			dictionary.Add(new ExchangeAvailableFundWrapper
			{
				AvailableCrypto = 1,
				ExchangeId = "ExchangeId"
			}, orderList);
			
			_orderService.GetAllSellOrders(data).Returns(dictionary);

			var result = _systemUnderTest.Buy(data, 1).ToList();
			result.Should().NotBeEmpty();
			result.Should().HaveCount(2);
			result[0].Price.Should().Be(50000);
			result[1].Price.Should().Be(50001);
		}

		[Test]
		public void Buy_NoDataProvided_ReturnsEmptyList()
		{
			var data = new List<Exchange>();
			
			var result = _systemUnderTest.Buy(data, 0).ToList();
			result.Should().BeEmpty();
		}

		[Test]
		public void Sell_ExchangeDataProvided_ReturnsListOfOrders()
		{
			var data = new List<Exchange>();
			var dictionary = new Dictionary<ExchangeAvailableFundWrapper, IOrderedEnumerable<Order>>();
			var orderList = new List<Order>
			{
				new ()
				{
					Amount = 0.5m,
					Price = 70000
				},
				new ()
				{
					Amount = 0.5m,
					Price = 50000
				},
				new ()
				{
					Amount = 0.5m,
					Price = 60000
				},
				new ()
				{
					Amount = 0.5m,
					Price = 50001
				}
			}.OrderByDescending(x =>x.Price);
			dictionary.Add(new ExchangeAvailableFundWrapper()
			{
				AvailableCrypto = 1
			}, orderList);
			_orderService.GetAllBuyOrders(data).Returns(dictionary);

			var result = _systemUnderTest.Sell(data, 1).ToList();
			result.Should().NotBeEmpty();
			result.Should().HaveCount(2);
			result[0].Price.Should().Be(70000);
			result[1].Price.Should().Be(60000);
		}

		[Test]
		public void Sell_NoDataProvided_ReturnsEmptyList()
		{
			var data = new List<Exchange>();

			var result = _systemUnderTest.Sell(data, 0).ToList();
			result.Should().BeEmpty();
		}
	}
}
