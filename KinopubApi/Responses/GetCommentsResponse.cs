using Newtonsoft.Json;

namespace KinopubApi.Responses;

public class GetCommentsResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("item")]
    public ContentItem Item { get; set; }

    [JsonProperty("comments")]
    public List<Comment> Comments { get; set; }

    public class Comment
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("depth")]
        public int Depth { get; set; }

        [JsonProperty("unread")]
        public bool Unread { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class ContentItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }
}
