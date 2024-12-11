﻿using CryptoExchange.Common.Services;
using CryptoExchange.WebApp.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace CryptoExchange.WebApp.Controllers
{
	/// <summary>
	/// Trading controller
	/// </summary>
	/// <param name="logger"></param>
	/// <param name="config"></param>
	/// <param name="exchangeService"></param>
	/// <param name="tradingService"></param>
	public class TradingController(
		ILogger<TradingController> logger,
		IConfiguration config,
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

			var settingsSection = config.GetSection("Settings");
			var settings = settingsSection.Get<Settings>();

			var exchangeData =  exchangeService.GetDataFromFiles(settings?.Source);
			var result = tradingService.Buy(exchangeData, numberOfBtc);

			return Ok(result);
		}
	}
}
