using ChromaDB.Client;

// include: Enum
var configOptions = new ChromaConfigurationOptions(uri: "http://localhost:8000/api/v1/");
using var httpClient = new HttpClient();
// accept options as arguments
var client = new ChromaClient(configOptions, httpClient);

Console.WriteLine(await client.GetVersion());

var string5Collection = await client.GetOrCreateCollection("string5");
var string5Client = new ChromaCollectionClient(string5Collection, configOptions, httpClient);

await string5Client.Add(["340a36ad-c38a-406c-be38-250174aee5a4"], embeddings: [new([1f, 0.5f, 0f, -0.5f, -1f])]);

var getData = await string5Client.Get(["340a36ad-c38a-406c-be38-250174aee5a4"], include: ChromaGetInclude.Metadatas | ChromaGetInclude.Documents | ChromaGetInclude.Embeddings);
foreach (var entry in getData)
{
	Console.WriteLine($"ID: {entry.Id}");
}

var queryData = await string5Client.Query([new([1f, 0.5f, 0f, -0.5f, -1f]), new([1.5f, 0f, 2f, -1f, -1.5f])], include: ChromaQueryInclude.Metadatas | ChromaQueryInclude.Distances);
foreach (var item in queryData)
{
	foreach (var entry in item)
	{
		Console.WriteLine($"ID: {entry.Id} | Distance: {entry.Distance}");
	}
}
