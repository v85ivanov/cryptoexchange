using Common.Models;

namespace Common.Services
{
	/// <summary>
	/// Represents the file reader service.
	/// </summary>
	public interface IFileReaderService
	{
		/// <summary>
		/// Creates collection of all exchanges provided.
		/// </summary>
		/// <param name="inputDirectoryPath">The input directory path.</param>
		/// <returns></returns>
		Task<ICollection<Exchange>> ReadExchangeFilesAsync(string inputDirectoryPath);
	}
}
