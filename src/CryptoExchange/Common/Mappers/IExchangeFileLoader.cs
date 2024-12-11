using CryptoExchange.Common.Models;

namespace CryptoExchange.Common.Mappers
{
	/// <summary>
	/// Represents exchange file mapper.
	/// </summary>
	public interface IExchangeFileLoader
	{
		/// <summary>
		/// Maps file info to exchange model.
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		Exchange GetData(FileInfo file);
	}
}
