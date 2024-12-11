using Microsoft.Extensions.Options;

namespace CryptoExchange.WebApp.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddOptionsFromSection<TOptions>(this IServiceCollection services, string sectionName,
		bool withoutBinding = false)
		where TOptions : class
	{
		if (services.All(s => s.ServiceType != typeof(IConfigureOptions<TOptions>)))
		{
			var optionsBuilder = services.AddOptions<TOptions>();
			if (!withoutBinding)
				optionsBuilder.BindConfiguration(sectionName);

			//TODO: Migration Do we need minivalidation?
			//optionsBuilder.ValidateMiniValidation(sectionName);
			optionsBuilder.ValidateOnStart();
		}

		return services;
	}
}