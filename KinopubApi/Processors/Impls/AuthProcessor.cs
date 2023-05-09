using KinopubApi.Processors.Interfaces;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Impls;

internal class AuthProcessor : IAuthProcessor
{
    private readonly HttpClient _httpClient;
    private readonly string _clientId;
    private readonly string _clientSecret;

    internal AuthProcessor(HttpClient httpClient, string clientId, string clientSecret)
    {
        _httpClient = httpClient;
        _clientId = clientId;
        _clientSecret = clientSecret;
    }

    public async Task<DeviceCodeResponse> GetDeviceCodeAsync()
    {
        return await _httpClient.SendRequestAsync<DeviceCodeResponse>(HttpMethod.Post, "/oauth2/device",
            new Dictionary<string, string>
            {
                { "grant_type", "device_code" },
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
            });
    }

    public async Task<DeviceTokenResponse> GetDeviceTokenAsync(string deviceCode)
    {
        return await _httpClient.SendRequestAsync<DeviceTokenResponse>(HttpMethod.Post, "/oauth2/device",
            new Dictionary<string, string>
            {
                { "grant_type", "device_token" },
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "code", deviceCode },
            });
    }

    public async Task<UpdateDeviceTokenResponse> UpdateDeviceTokenAsync(string refreshToken)
    {
        return await _httpClient.SendRequestAsync<UpdateDeviceTokenResponse>(HttpMethod.Post, "/oauth2/token",
            new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "refresh_token", refreshToken },
            });
    }
}