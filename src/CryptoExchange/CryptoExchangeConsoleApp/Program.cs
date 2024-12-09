﻿using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Common.Models;
using Common.Services;
using Microsoft.Extensions.Logging;
using static System.Text.Json.JsonSerializer;

namespace CryptoExchangeConsoleApp;

public class Program
{
	private static ServiceProvider? _serviceProvider;

	private static void Main(string[] args)
	{
		IServiceCollection services = new ServiceCollection();
		ConfigureServices(services);
		_serviceProvider = services.BuildServiceProvider();

		var orders = new List<Order>();
		Parser.Default.ParseArguments<Arguments>(args)
			.WithParsed(a =>
			{
				orders = BuyBtc(a.Source, 1).ToList();
			});
		LogToConsole(orders);
		Console.ReadLine();
	}

	/// <summary>
	/// Configure the services.
	/// </summary>
	/// <param name="services"></param>
	private static void ConfigureServices(IServiceCollection services)
	{
		//Configure logger
		services.AddLogging(builder => builder.ClearProviders().AddConsole());
		//Add services
		services.AddCommonServices();
	}

	/// <summary>
	/// Buys BTC.
	/// </summary>
	/// <param name="inputDirectory"></param>
	/// <param name="numberOfBtc"></param>
	/// <returns></returns>
	private static IEnumerable<Order> BuyBtc(string inputDirectory, int numberOfBtc)
	{
		var exchangeService = _serviceProvider.GetService<IExchangeService>();
		var exchanges = exchangeService?.GetDataFromFiles(inputDirectory);

		var tradingService = _serviceProvider.GetService<ITradingService>();
		return tradingService?.Buy(exchanges, numberOfBtc);
	}

	/// <summary>
	/// Logs orders list to the console.
	/// </summary>
	/// <param name="orders"></param>
	private static void LogToConsole(List<Order> orders)
	{
		using var scope = _serviceProvider.CreateScope();
		var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
		foreach (var order in orders)
		{
			logger.LogInformation(message: Serialize(order));
		}
	}

}