using Newtonsoft.Json;

namespace KinopubApi.Responses;

public class GetVideoQualityResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("items")]
    public List<Item> Items { get; set; }

    public class Item
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("quality")]
        public int Quality { get; set; }
    }
}
