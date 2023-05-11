using Newtonsoft.Json;

namespace KinopubApi.Responses;

public class GetTvChannelsResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("channels")]
    public List<Channel> Channels { get; set; }

    public class Channel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("logos")]
        public Logos Logos { get; set; }

        [JsonProperty("stream")]
        public string Stream { get; set; }

        [JsonProperty("embed")]
        public string Embed { get; set; }

        [JsonProperty("current")]
        public string Current { get; set; }

        [JsonProperty("playlist")]
        public string Playlist { get; set; }

        [JsonProperty("status")]
        public object Status { get; set; }
    }

    public class Logos
    {
        [JsonProperty("s")]
        public string S { get; set; }

        [JsonProperty("m")]
        public string M { get; set; }
    }
}
