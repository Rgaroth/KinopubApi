namespace KinopubApi.Processors;

internal abstract class BaseProcessor
{
    protected readonly HttpClient HttpClient;
    protected readonly string ClientId;
    protected readonly string ClientSecret;

    internal BaseProcessor(HttpClient httpClient, string clientId, string clientSecret)
    {
        HttpClient = httpClient;
        ClientId = clientId;
        ClientSecret = clientSecret;
    }
}