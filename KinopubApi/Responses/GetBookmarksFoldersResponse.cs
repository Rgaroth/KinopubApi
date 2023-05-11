using Newtonsoft.Json;

namespace KinopubApi.Responses;

public class GetBookmarksFoldersResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("items")]
    public List<Item> Items { get; set; }

    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("updated")]
        public int Updated { get; set; }
    }
}
