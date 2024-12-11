using CryptoExchange.Common.Models;
using CryptoExchange.Common.Services;
using CryptoExchange.WebApp.Configuration;
using Microsoft.Extensions.Options;

namespace CryptoExchange.WebApp.Services
{

	public class SalesService(
		IOptions<Settings> settings,
		IExchangeService exchangeService,
		ITradingService tradingService,
		ILogger<SalesService> logger)
		: ISalesService
	{
		
		public ICollection<Order> Buy(int numberOfBtc)
		{
			logger.LogInformation("Buying {NumberOfBtc} BTC", numberOfBtc);

			var exchangeData = exchangeService.GetDataFromFiles(settings.Value.Source);
			var result = tradingService.Buy(exchangeData, numberOfBtc);
			return result;
		}

		public ICollection<Order> Sell(int numberOfBtc)
		{
			logger.LogInformation("Selling {NumberOfBtc} BTC", numberOfBtc);

			var exchangeData = exchangeService.GetDataFromFiles(settings.Value.Source);
			var result = tradingService.Buy(exchangeData, numberOfBtc);
			return result;
		}
	}
}
