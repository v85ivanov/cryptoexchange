﻿using Common.Mappers;
using Common.Providers;
using Common.Services;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddCommonServices(this IServiceCollection services)
	{

		//mappers
		services.AddTransient<IExchangeFileLoader, ExchangeFileLoader>();

		//providers
		services.AddTransient<IFileProvider, PhysicalFileProvider>();

		//services
		services.AddTransient<IExchangeService, ExchangeService>();
		services.AddTransient<IOrderService, OrderService>();
		services.AddTransient<ITradingService, TradingService>();

		return services;
	}
}