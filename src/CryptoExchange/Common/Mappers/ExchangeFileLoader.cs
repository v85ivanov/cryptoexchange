using Common.Models;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Common.Mappers
{
	/// <summary>
	/// Implementation of <see cref="IExchangeFileLoader"/>.
	/// </summary>
	internal class ExchangeFileLoader(ILogger<ExchangeFileLoader> logger) : IExchangeFileLoader
	{

		public Exchange? GetData(FileInfo file)
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
