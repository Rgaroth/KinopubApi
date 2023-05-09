using Microsoft.Extensions.Configuration;

namespace KinopubApi.Tests;

public abstract class BaseTest
{
    private static IConfigurationRoot Config;

    static BaseTest()
    {
        Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    }

    [OneTimeSetUp]
    public void Initialize()
    {
        var actionLogClientSettings = Config.GetSection(nameof(ApiClientSettings)).Get<ApiClientSettings>();

        var httpClient = new HttpClient(new HttpClientHandler())
        {
            BaseAddress = new Uri(actionLogClientSettings.BaseUrl),
            Timeout = actionLogClientSettings.Timeout
        };

        OnInitialize(httpClient, actionLogClientSettings);
    }

    protected abstract void OnInitialize(HttpClient httpClient, ApiClientSettings settings);

}