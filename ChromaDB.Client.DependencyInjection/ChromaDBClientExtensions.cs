using ChromaDB.Client.Common.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace ChromaDB.Client.DependencyInjection;

public static class ChromaDBClientExtensions
{
	public static void AddChromaDBClient(this IServiceCollection services, Func<ConfigurationOptions?, ConfigurationOptions>? configurationOptions = null)
	{
		configurationOptions ??= DefaultConfigurationOptions;

		ConfigurationOptions options = new();
		options = configurationOptions(options);

		services.AddScoped<ChromaDBClient>();
		services.AddHttpClient<ChromaDBClient>(o =>
		{
			o.BaseAddress = options.Uri;
		});
	}

	private static ConfigurationOptions DefaultConfigurationOptions(ConfigurationOptions? options = null)
		=> options ?? new ConfigurationOptions(new Uri(ClientConstants.DefaultUri));
}