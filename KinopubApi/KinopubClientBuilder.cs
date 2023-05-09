using System.Net.Http;
using KinopubApi.Exceptions;

namespace KinopubApi;

public class KinopubClientBuilder
{
    private string _clientId;
    private string _clientSecret;
    private HttpClient _httpClient;
    private HttpClientHandler _httpClientHandler;

    public static KinopubClientBuilder CreateBuilder()
    {
        return new KinopubClientBuilder();
    }

    public KinopubClientBuilder AddApiKeys(string clientId, string clientSecret)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;

        return this;
    }

    public KinopubClientBuilder UseHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;

        return this;
    }

    public KinopubClientBuilder UseHttpClientHandler(HttpClientHandler httpClientHandler)
    {
        _httpClientHandler = httpClientHandler;

        return this;
    }

    public KinopubClient Build()
    {
        if (string.IsNullOrEmpty(_clientId) || string.IsNullOrEmpty(_clientSecret))
        {
            throw new InvalidCredentialsException(@"Use ""AddApiKeys"" method in builder to add Kinopub API keys");
        }

        _httpClient ??= new HttpClient(_httpClientHandler ?? new HttpClientHandler());

        return new KinopubClient(_httpClient, _clientId, _clientSecret);
    }
}