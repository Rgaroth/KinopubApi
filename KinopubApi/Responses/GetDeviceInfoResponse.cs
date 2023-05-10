using Newtonsoft.Json;
using static KinopubApi.Responses.GetDevicesResponse;

namespace KinopubApi.Responses;

public class GetDeviceInfoResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("device")]
    public Device Device { get; set; }
}
