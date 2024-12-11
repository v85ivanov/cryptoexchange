using CommandLine;

namespace CryptoExchange.ConsoleApp;

/// <summary>
/// Represents the arguments model.
/// </summary>
internal class Arguments
{
	[Option('s', "source", Required = true, HelpText = "Set source directory.")]
	public required string Source { get; set; }

	[Option('b', "btc", Required = true, HelpText = "Set number of btc to buy/sell.")]
	public required int Btc { get; set; }

	[Option('a', "action", Required = true, HelpText = "Set 'Buy' or 'Sell'.")]
	public required string Action { get; set; }

}