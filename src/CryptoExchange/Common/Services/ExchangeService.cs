using CryptoExchange.Common.Mappers;
using CryptoExchange.Common.Models;
using CryptoExchange.Common.Providers;
using Microsoft.Extensions.Logging;

namespace CryptoExchange.Common.Services
{
	/// <summary>
	/// Implementation of <see cref="IExchangeService"/>.
	/// </summary>
	/// <param name="fileProvider"></param>
	/// <param name="exchangeFileLoader"></param>
	/// <param name="logger"></param>
	internal class ExchangeService(
		IFileProvider fileProvider,
		IExchangeFileLoader exchangeFileLoader,
		ILogger<ExchangeService> logger)
		: IExchangeService
	{
		public ICollection<Exchange> GetDataFromFiles(string directoryPath)
		{
			if (!string.IsNullOrEmpty(directoryPath))
			{
				logger.LogInformation("Getting exchange data");

				var files = fileProvider.GetFiles(directoryPath);
				return files.Select(exchangeFileLoader.GetData).OfType<Exchange>().ToList();
			}
			return new List<Exchange>();
		}
	}
}
