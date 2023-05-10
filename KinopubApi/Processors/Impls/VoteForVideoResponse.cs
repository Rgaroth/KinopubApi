using Newtonsoft.Json;

namespace KinopubApi.Processors.Impls
{
    public class VoteForVideoResponse
    {
        [JsonProperty("voted")]
        public bool Voted { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("positive")]
        public string Positive { get; set; }

        [JsonProperty("negative")]
        public string Negative { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }
    }
}
