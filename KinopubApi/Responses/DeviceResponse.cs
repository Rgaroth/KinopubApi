using Newtonsoft.Json;

namespace KinopubApi.Responses;

internal class DeviceResponse
{
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("user_code")]
    public string UserCode { get; set; }

    [JsonProperty("verification_uri")]
    public string VerificationUri { get; set; }

    [JsonProperty("interval")]
    public int Interval { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }
}