using ChromaDB.Client.Models;

namespace ChromaDB.Client;

//embedding -> ROM<float>
public interface IChromaDBCollectionClient
{
	Collection Collection { get; }

	// single overload
	Task<Response<List<CollectionEntry>>> Get(List<string>? ids = null, Dictionary<string, object>? where = null, Dictionary<string, object>? whereDocument = null, int? limit = null, int? offset = null, List<string>? include = null);
	// single List overload
	Task<Response<List<List<CollectionQueryEntry>>>> Query(List<List<float>> queryEmbeddings, int nResults = 10, Dictionary<string, object>? where = null, Dictionary<string, object>? whereDocument = null, List<string>? include = null);
	Task<Response<Response.Empty>> Add(List<string> ids, List<List<float>>? embeddings = null, List<Dictionary<string, object>>? metadatas = null, List<string>? documents = null);
	Task<Response<Response.Empty>> Update(List<string> ids, List<List<float>>? embeddings = null, List<Dictionary<string, object>>? metadatas = null, List<string>? documents = null);
	Task<Response<Response.Empty>> Upsert(List<string> ids, List<List<float>>? embeddings = null, List<Dictionary<string, object>>? metadatas = null, List<string>? documents = null);
	Task<Response<Response.Empty>> Delete(List<string> ids, Dictionary<string, object>? where = null, Dictionary<string, object>? whereDocument = null);
	Task<Response<int>> Count();
	Task<Response<List<CollectionEntry>>> Peek(int limit = 10);
	Task<Response<Response.Empty>> Modify(string? name = null, Dictionary<string, object>? metadata = null);
}
