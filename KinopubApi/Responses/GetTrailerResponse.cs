using Newtonsoft.Json;

namespace KinopubApi.Responses;

public class GetTrailerResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("trailer")]
    public List<TrailerItem> Trailer { get; set; }

    public class TrailerItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

}
