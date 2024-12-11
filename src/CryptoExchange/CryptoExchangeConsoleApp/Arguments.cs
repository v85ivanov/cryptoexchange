using CommandLine;

namespace CryptoExchangeConsoleApp;

/// <summary>
/// Represents the arguments model.
/// </summary>
internal class Arguments
{
	[Option('s', "source", Required = true, HelpText = "Set source directory.")]
	public required string Source { get; set; }

}