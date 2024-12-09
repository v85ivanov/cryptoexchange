using Microsoft.Extensions.DependencyInjection;

namespace CryptoExchangeConsoleApp
{
	public class Program
	{
		static void Main(string[] args)
		{
			IServiceCollection services = new ServiceCollection();
			ConfigureServices(services);

			//Initialize services

		}

		/// <summary>
		/// Configure the services
		/// </summary>
		/// <param name="services"></param>
		private static void ConfigureServices(IServiceCollection services)
		{
			//Configure the services

		}
	}
}
