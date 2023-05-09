using KinopubApi.Client;
using KinopubApi.Exceptions;

namespace KinopubApi.Builder;

public class KinopubClientBuilder : IKinopubClientBuilder
{
    private string _clientId;
    private string _clientSecret;
    private HttpClient _httpClient;
    private HttpClientHandler _httpClientHandler;

    public static KinopubClientBuilder CreateBuilder()
    {
        return new KinopubClientBuilder();
    }

    public IKinopubClientBuilder AddApiKeys(string clientId, string clientSecret)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;

        return this;
    }

    public IKinopubClientBuilder UseHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;

        return this;
    }

    public IKinopubClientBuilder UseHttpClientHandler(HttpClientHandler httpClientHandler)
    {
        _httpClientHandler = httpClientHandler;

        return this;
    }

    public IKinopubClient Build()
    {
        if (string.IsNullOrEmpty(_clientId) || string.IsNullOrEmpty(_clientSecret))
        {
            throw new InvalidCredentialsException(@"Use ""AddApiKeys"" method in builder to add Kinopub API keys");
        }

        _httpClient ??= new HttpClient(_httpClientHandler ?? new HttpClientHandler())
        {
            BaseAddress = new Uri("https://api.service-kp.com/")
        };

        return new KinopubClient(_httpClient, _clientId, _clientSecret);
    }
}