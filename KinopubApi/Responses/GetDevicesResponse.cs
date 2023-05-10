using Newtonsoft.Json;

namespace KinopubApi.Responses;

public  class GetDevicesResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("devices")]
    public List<Device> Devices { get; set; }

    public class Device
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("hardware")]
        public string Hardware { get; set; }

        [JsonProperty("software")]
        public string Software { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("updated")]
        public int Updated { get; set; }

        [JsonProperty("last_seen")]
        public int LastSeen { get; set; }

        [JsonProperty("is_browser")]
        public bool IsBrowser { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }
    }

    public class MixedPlaylist
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class ServerLocation
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public List<Value> Value { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class Settings
    {
        [JsonProperty("supportSsl")]
        public SupportSsl SupportSsl { get; set; }

        [JsonProperty("supportHevc")]
        public SupportHevc SupportHevc { get; set; }

        [JsonProperty("supportHdr")]
        public SupportHdr SupportHdr { get; set; }

        [JsonProperty("support4k")]
        public Support4k Support4k { get; set; }

        [JsonProperty("mixedPlaylist")]
        public MixedPlaylist MixedPlaylist { get; set; }

        [JsonProperty("serverLocation")]
        public ServerLocation ServerLocation { get; set; }

        [JsonProperty("streamingType")]
        public StreamingType StreamingType { get; set; }
    }

    public class StreamingType
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public List<Value> Value { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class Support4k
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class SupportHdr
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class SupportHevc
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class SupportSsl
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class Value
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("selected")]
        public int Selected { get; set; }
    }
}
