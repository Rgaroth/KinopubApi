using KinopubApi.Builder;
using KinopubApi.Client;
using Microsoft.Extensions.Configuration;

namespace KinopubApi.Tests.Base;

public abstract class BaseTest
{
    protected KinopubClient _notAuthClient;
    protected KinopubClient _client;
    protected string _accessToken;

    private static IConfigurationRoot Config;

    public BaseTest()
    {
        Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    }

    [OneTimeSetUp]
    public void Initialize()
    {
        var settings = Config.GetSection(nameof(ApiClientSettings)).Get<ApiClientSettings>();

        var httpClient = new HttpClient(new HttpClientHandler())
        {
            BaseAddress = new Uri(settings.BaseUrl),
            Timeout = settings.Timeout
        };

        _notAuthClient = new KinopubClient(httpClient, settings.ClientId, settings.ClientSecret);
        _client = new KinopubClient(settings.TestAccessToken, null, httpClient, settings.ClientId, settings.ClientSecret);

        _accessToken = settings.TestAccessToken;
    }
}