using Common.Models;
using Microsoft.Extensions.Logging;

namespace Common.Services
{
	internal class FileReaderService : IFileReaderService
	{
		private readonly ILogger<FileReaderService> _logger;

		public FileReaderService(ILogger<FileReaderService> logger)
		{
			_logger = logger;
		}

		public Task<ICollection<Exchange>> ReadExchangeFilesAsync(string inputDirectoryPath)
		{
			_logger.LogDebug("Start reading from directory with path: {InputDirectoryPath}", inputDirectoryPath);

			throw new NotImplementedException();
		}
	}
}
