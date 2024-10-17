using NUnit.Framework;

namespace ChromaDB.Client.Tests;

[TestFixture]
public class CollectionClientCUDTests : ChromaDBTestsBase
{
	[Test]
	public async Task AddJustIds()
	{
		var client = await Init();
		var result = await client.Add([$"{Guid.NewGuid()}"]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task AddWithEmbeddings()
	{
		var client = await Init();
		var result = await client.Add([$"{Guid.NewGuid()}"],
			embeddings: [[1f, 0.5f, 0f, -0.5f, -1f]]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task AddWithMetadatas()
	{
		var client = await Init();
		var result = await client.Add([$"{Guid.NewGuid()}"],
			metadatas: [new Dictionary<string, object>
			{
				{ "key", "value" },
				{ "key2", 10 },
			}]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task AddWithDocuments()
	{
		var client = await Init();
		var result = await client.Add([$"{Guid.NewGuid()}"],
			documents: ["test"]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task AddWithAll()
	{
		var client = await Init();
		var result = await client.Add([$"{Guid.NewGuid()}"],
			embeddings: [[1f, 0.5f, 0f, -0.5f, -1f]],
			metadatas: [new Dictionary<string, object>
			{
				{ "key", "value" },
				{ "key2", 10 },
			}],
			documents: ["test"]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task UpdateNothing()
	{
		var id = $"{Guid.NewGuid()}";

		var client = await Init();
		await client.Add([id]);
		var result = await client.Update([id]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task UpdateEmbeddings()
	{
		var id = $"{Guid.NewGuid()}";

		var client = await Init();
		await client.Add([id]);
		var result = await client.Update([id],
			embeddings: [[1f, 0.5f, 0f, -0.5f, -1f]]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task UpdateMetadatas()
	{
		var id = $"{Guid.NewGuid()}";

		var client = await Init();
		await client.Add([id]);
		var result = await client.Update([id],
			metadatas: [new Dictionary<string, object>
			{
				{ "key", "value" },
				{ "key2", 10 },
			}]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task UpdateDocuments()
	{
		var id = $"{Guid.NewGuid()}";

		var client = await Init();
		await client.Add([id]);
		var result = await client.Update([id],
			documents: ["test"]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task UpdateAll()
	{
		var id = $"{Guid.NewGuid()}";

		var client = await Init();
		await client.Add([id]);
		var result = await client.Update([id],
			embeddings: [[1f, 0.5f, 0f, -0.5f, -1f]],
			metadatas: [new Dictionary<string, object>
			{
				{ "key", "value" },
				{ "key2", 10 },
			}],
			documents: ["test"]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task UpsertJustIds()
	{
		var client = await Init();
		var result = await client.Upsert([$"{Guid.NewGuid()}"]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task UpsertWithEmbeddings()
	{
		var client = await Init();
		var result = await client.Upsert([$"{Guid.NewGuid()}"],
			embeddings: [[1f, 0.5f, 0f, -0.5f, -1f]]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task UpsertWithMetadatas()
	{
		var client = await Init();
		var result = await client.Upsert([$"{Guid.NewGuid()}"],
			metadatas: [new Dictionary<string, object>
			{
				{ "key", "value" },
				{ "key2", 10 },
			}]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task UpsertWithDocuments()
	{
		var client = await Init();
		var result = await client.Upsert([$"{Guid.NewGuid()}"],
			documents: ["test"]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task UpsertWithAll()
	{
		var client = await Init();
		var result = await client.Upsert([$"{Guid.NewGuid()}"],
			embeddings: [[1f, 0.5f, 0f, -0.5f, -1f]],
			metadatas: [new Dictionary<string, object>
			{
				{ "key", "value" },
				{ "key2", 10 },
			}],
			documents: ["test"]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task DeleteByIdExisting()
	{
		var id = $"{Guid.NewGuid()}";

		var client = await Init();
		await client.Add([id]);
		var result = await client.Delete([id]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task DeleteByIdNonExisting()
	{
		var id = $"{Guid.NewGuid()}";

		var client = await Init();
		var result = await client.Delete([id]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task DeleteByMultipleIds()
	{
		var id1 = $"{Guid.NewGuid()}";
		var id2 = $"{Guid.NewGuid()}";

		var client = await Init();
		await client.Add([id1, id2]);
		var result = await client.Delete([id1, id2]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task DeleteByMultipleIdsOneNonExisting()
	{
		var id1 = $"{Guid.NewGuid()}";
		var id2 = $"{Guid.NewGuid()}";

		var client = await Init();
		await client.Add([id1]);
		var result = await client.Delete([id1, id2]);
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task DeleteByMultipleIdsWithWhere()
	{
		var id1 = $"{Guid.NewGuid()}";
		var id2 = $"{Guid.NewGuid()}";

		var client = await Init();
		await client.Add([id1, id2],
			metadatas: [new Dictionary<string, object>
			{
			}, new Dictionary<string, object>
			{
				{ "key", "value" },
			}]);
		var result = await client.Delete([id1, id2],
			where: new Dictionary<string, object>
			{
				{ "key", "value" },
			});
		Assert.That(result.Success, Is.True);
	}

	[Test]
	public async Task DeleteByMultipleIdsWithWhereDocument()
	{
		var id1 = $"{Guid.NewGuid()}";
		var id2 = $"{Guid.NewGuid()}";

		var client = await Init();
		await client.Add([id1, id2],
			documents: ["Doc1", "Doc2"]);
		var result = await client.Delete([id1, id2],
			whereDocument: new Dictionary<string, object>
			{
				{ "$contains", "2" },
			});
		Assert.That(result.Success, Is.True);
	}

	async Task<ChromaDBCollectionClient> Init()
	{
		var name = $"collection{Random.Shared.Next()}";
		var client = new ChromaDBClient(ConfigurationOptions, HttpClient);
		var collectionResponse = await client.GetOrCreateCollection(name);
		Assert.That(collectionResponse.Success, Is.True);
		var collection = collectionResponse.Data!;
		return new ChromaDBCollectionClient(collection, ConfigurationOptions, HttpClient);
	}
}
