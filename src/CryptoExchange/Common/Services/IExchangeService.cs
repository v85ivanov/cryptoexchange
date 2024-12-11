using CryptoExchange.Common.Models;

namespace CryptoExchange.Common.Services
{
	/// <summary>
	/// Represents the exchange service.
	/// </summary>
	public interface IExchangeService
	{
		/// <summary>
		/// Gets exchange data from directory
		/// </summary>
		/// <param name="directoryPath"></param>
		/// <returns></returns>
		ICollection<Exchange> GetDataFromFiles(string directoryPath);
	}
}
