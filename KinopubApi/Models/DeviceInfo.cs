using Newtonsoft.Json;

namespace KinopubApi.Models;

public class DeviceInfo
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("hardware")]
    public string Hardware { get; set; }

    [JsonProperty("software")]
    public string Software { get; set; }
}
