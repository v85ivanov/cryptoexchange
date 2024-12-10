using CryptoExchangeWebApp.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace CryptoExchangeWebApp.Controllers
{
	public class TradingController : Controller
	{
		private readonly ILogger<TradingController> _logger;
		private readonly IConfiguration _config;

		public TradingController(ILogger<TradingController> logger, IConfiguration config)
		{
			_logger = logger;
			_config = config;
		}

		[HttpGet]
		public IActionResult Buy(int numberOfBtc)
		{
			var settingsSection = _config.GetSection("Settings");
			var settings = settingsSection.Get<Settings>();


			_logger.LogInformation("Buying {NumberOfBtc} BTC", numberOfBtc);
			return Ok();
		}
	}
}
