using Newtonsoft.Json;
using static KinopubApi.Responses.GetItemResponse;

namespace KinopubApi.Responses;

public class GetSubtitlesAndVideosResponse
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("files")]
    public List<GetItemResponse.File> Files { get; set; }

    [JsonProperty("subtitles")]
    public List<Subtitle> Subtitles { get; set; }
}
