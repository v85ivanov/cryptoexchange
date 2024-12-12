using System.Text.Json;
using CryptoExchange.Common.Models;
using Microsoft.Extensions.Logging;

namespace CryptoExchange.Common.Mappers
{
	/// <summary>
	/// Implementation of <see cref="IExchangeFileMapper"/>.
	/// </summary>
	internal class ExchangeFileMapper(ILogger<ExchangeFileMapper> logger) : IExchangeFileMapper
	{

		public Exchange GetData(FileInfo file)
		{
			try
			{
				using var r = new StreamReader(file.FullName);
				var json = r.ReadToEnd();
				return JsonSerializer.Deserialize<Exchange>(json);
			}
			catch (Exception e)
			{
				logger.LogError(e, "Unable for deserialize file with {FileName}", file.Name);
				return null;
			}
		}
	}
}
