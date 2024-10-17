namespace ChromaDB.Client;

// kill this -Shay (2024)
public class ChromaDBHttpClient : HttpClient
{
	private readonly ConfigurationOptions _config;

	public ChromaDBHttpClient(ConfigurationOptions configurationOptions)
	{
		_config = configurationOptions;
		BaseAddress = _config.Uri;
	}
}
