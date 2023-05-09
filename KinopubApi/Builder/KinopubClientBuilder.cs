using KinopubApi.Client;
using KinopubApi.Exceptions;

namespace KinopubApi.Builder;

public class KinopubClientBuilder : IKinopubClientBuilder
{
    private string _clientId;
    private string _clientSecret;
    private HttpClient _httpClient;
    private HttpClientHandler _httpClientHandler;
    private string _accessToken;
    private string _refreshToken;

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

    public IKinopubClientBuilder UseToken(string accessToken, string refreshToken)
    {
        _accessToken = accessToken;
        _refreshToken = refreshToken;

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

        var client = _accessToken != null 
            ? new KinopubClient(_accessToken, _refreshToken, _httpClient, _clientId, _clientSecret)
            : new KinopubClient(_httpClient, _clientId, _clientSecret);

        return client;
    }
}