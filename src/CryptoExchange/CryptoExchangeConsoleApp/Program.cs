using Microsoft.Extensions.DependencyInjection;
using Common.Models;
using Common.Services;
using Microsoft.Extensions.Logging;

namespace CryptoExchangeConsoleApp
{
	public class Program
	{
		private static ServiceProvider? _serviceProvider;

		private static void Main(string[] args)
		{
			IServiceCollection services = new ServiceCollection();
			ConfigureServices(services);
			_serviceProvider = services.BuildServiceProvider();

			var result = BuyBtc(@"C:\Temp\exchanges", 1);
		}

		/// <summary>
		/// Configure the services
		/// </summary>
		/// <param name="services"></param>
		private static void ConfigureServices(IServiceCollection services)
		{
			//Configure logger
			services.AddLogging(builder => builder.AddConsole());
			//Add services
			services.AddCommonServices();
		}

		private static IEnumerable<Order> BuyBtc(string inputDirectory, int numberOfBtc)
		{
			var exchangeService = _serviceProvider.GetService<IExchangeService>();
			var exchanges = exchangeService?.GetDataFromFiles(inputDirectory);

			var tradingService = _serviceProvider.GetService<ITradingService>();
			return tradingService?.Buy(exchanges, numberOfBtc);
		}
	}
}
