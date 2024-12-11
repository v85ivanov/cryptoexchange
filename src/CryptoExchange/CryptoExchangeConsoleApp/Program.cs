using CommandLine;
using CryptoExchange.Common.Models;
using CryptoExchange.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static System.Text.Json.JsonSerializer;

namespace CryptoExchange.ConsoleApp;

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
				orders = (BuyBtc(a.Source, 1) ?? Array.Empty<Order>()).ToList();
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
	private static IEnumerable<Order>? BuyBtc(string inputDirectory, int numberOfBtc)
	{
		if (_serviceProvider != null)
		{
			var exchangeService = _serviceProvider.GetService<IExchangeService>();
			var exchanges = exchangeService?.GetDataFromFiles(inputDirectory);

			var tradingService = _serviceProvider.GetService<ITradingService>();
			return tradingService?.Buy(exchanges, numberOfBtc);
		}

		return null;
	}

	/// <summary>
	/// Logs orders list to the console.
	/// </summary>
	/// <param name="orders"></param>
	private static void LogToConsole(List<Order> orders)
	{
		if (_serviceProvider != null)
		{
			using var scope = _serviceProvider.CreateScope();
			var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
			foreach (var order in orders)
			{
				logger.LogInformation(message: Serialize(order));
			}
		}
	}

}