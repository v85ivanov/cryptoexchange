﻿using CryptoExchange.Common.Mappers;
using CryptoExchange.Common.Providers;
using CryptoExchange.Common.Services;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddTradingServices(this IServiceCollection services)
	{

		//mappers
		services.AddTransient<IExchangeFileMapper, ExchangeFileMapper>();

		//providers
		services.AddTransient<IFileProvider, PhysicalFileProvider>();

		//services
		services.AddTransient<IExchangeService, ExchangeService>();
		services.AddTransient<IOrderService, OrderService>();
		services.AddTransient<ITradingService, TradingService>();

		return services;
	}
}