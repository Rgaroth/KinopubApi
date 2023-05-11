using Newtonsoft.Json;
using static KinopubApi.Responses.GetItemsByBookmarkIdResponse;

namespace KinopubApi.Responses;

public class CreateFolderResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("folder")]
    public FolderItem Folder { get; set; }
}
