﻿namespace ChromaDB.Client;

public class ChromaDBHttpClient : HttpClient, IChromaDBHttpClient
{
	private readonly ConfigurationOptions _config;

	public ChromaDBHttpClient(ConfigurationOptions configurationOptions)
	{
		_config = configurationOptions;
		BaseAddress = _config.Uri;
	}
}
