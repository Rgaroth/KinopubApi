using Newtonsoft.Json;
using static KinopubApi.Responses.GetDevicesResponse;

namespace KinopubApi.Responses;

public class GetDeviceSettingsResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("settings")]
    public Settings Settings { get; set; }
}
