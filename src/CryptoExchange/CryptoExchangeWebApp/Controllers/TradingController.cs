using CryptoExchange.Common.Services;
using CryptoExchange.WebApp.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CryptoExchange.WebApp.Controllers
{
	/// <summary>
	/// Trading controller
	/// </summary>
	/// <param name="logger"></param>
	/// <param name="settings"></param>
	/// <param name="exchangeService"></param>
	/// <param name="tradingService"></param>
	public class TradingController(
		ILogger<TradingController> logger,
		IOptions<Settings> settings,
		IExchangeService exchangeService,
		ITradingService tradingService)
		: ControllerBase
	{
		/// <summary>
		/// Buys BTC.
		/// </summary>
		/// <param name="numberOfBtc"></param>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Buy(int numberOfBtc)
		{
			logger.LogInformation("Buying {NumberOfBtc} BTC", numberOfBtc);

			var exchangeData =  exchangeService.GetDataFromFiles(settings.Value.Source);
			var result = tradingService.Buy(exchangeData, numberOfBtc);

			return Ok(result);
		}
	}
}
