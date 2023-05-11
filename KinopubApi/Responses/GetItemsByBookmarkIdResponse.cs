using Newtonsoft.Json;
using static KinopubApi.Responses.GetItemsResponse;

namespace KinopubApi.Responses;

public class GetItemsByBookmarkIdResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("folder")]
    public FolderItem Folder { get; set; }

    [JsonProperty("items")]
    public List<Item> Items { get; set; }

    public class FolderItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("views")]
        public int? Views { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("updated")]
        public int Updated { get; set; }
    }
}
