using CommandLine;
using CryptoExchange.Common.Models;
using CryptoExchange.Common.Services;
using CryptoExchange.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static System.Text.Json.JsonSerializer;


IServiceCollection services = new ServiceCollection();
//Configure logger
services.AddLogging(builder => builder.AddConsole());
//Add services
services.AddCommonOrderServices();
var serviceProvider = services.BuildServiceProvider();

var orders = new List<Order>();
Parser.Default.ParseArguments<Arguments>(args)
	.WithParsed(a =>
	{
		orders = (TradeBtc(a.Action, a.Source, a.Btc) ?? Array.Empty<Order>()).ToList();
	});
LogToConsole(orders);
Console.ReadLine();
return;


IEnumerable<Order>? TradeBtc(string action, string inputDirectory, int numberOfBtc)
{
	var exchangeService = serviceProvider.GetService<IExchangeService>();
	var exchanges = exchangeService?.GetDataFromFiles(inputDirectory);
	
	var tradingService = serviceProvider.GetService<ITradingService>();
	if (string.Equals("Buy", action, StringComparison.OrdinalIgnoreCase))
	{
		return tradingService?.Buy(exchanges, numberOfBtc);
	}

	return string.Equals("Sell", action, StringComparison.OrdinalIgnoreCase)
		? tradingService?.Sell(exchanges, numberOfBtc) 
		: null;
}

void LogToConsole(List<Order> ordersToLog)
{
	using var scope = serviceProvider.CreateScope();
	var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
	foreach (var order in ordersToLog)
	{
		logger.LogInformation(message: Serialize(order));
	}
}