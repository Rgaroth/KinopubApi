namespace KinopubApi.Tests.Base;

public class ApiClientSettings
{
    public string BaseUrl { get; set; }
    public TimeSpan Timeout { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string TestAccessToken { get; set; }
}