using Newtonsoft.Json;

namespace KinopubApi.Responses;

public class GetStreamingTypeResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("items")]
    public List<Item> Items { get; set; }

    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}