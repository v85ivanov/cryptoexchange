using Common.Mappers;
using Common.Models;
using Common.Providers;
using Common.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;

namespace Common.Tests.Services
{
	public class ExchangeServiceTests
	{
		private ExchangeService _systemUnderTest;
		private IFileProvider _fileProvider;
		private IExchangeFileLoader _exchangeFileLoader;

		[SetUp]
		public void Setup()
		{
			var logger = Substitute.For<ILogger<ExchangeService>>();
			_fileProvider = Substitute.For<IFileProvider>();
			_exchangeFileLoader = Substitute.For<IExchangeFileLoader>();

			_systemUnderTest = Substitute.ForPartsOf<ExchangeService>(_fileProvider, _exchangeFileLoader, logger);
		}

		[Test]
		public void ReadExchangeFiles_ShouldReturnListOfObjects()
		{
			var fileInfo = new FileInfo("fileName");
			_fileProvider.GetFiles(Arg.Any<string>()).Returns([fileInfo]);
			_exchangeFileLoader.GetData(fileInfo).Returns(new Exchange());

			var result = _systemUnderTest.GetDataFromFiles("directoryPath").ToList();
			result.Should().NotBeEmpty();
			result.Should().HaveCount(1);
			result.ForEach(x => x.Should().BeOfType<Exchange>());

		}
	}
}
