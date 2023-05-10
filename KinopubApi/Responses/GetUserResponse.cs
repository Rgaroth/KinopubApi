using Newtonsoft.Json;

namespace KinopubApi.Responses
{
    public class GetUserResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class Profile
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }

    public class Subscription
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("end_time")]
        public long EndTime { get; set; }

        [JsonProperty("days")]
        public double Days { get; set; }
    }

    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("reg_date")]
        public string RegDate { get; set; }

        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }
}
