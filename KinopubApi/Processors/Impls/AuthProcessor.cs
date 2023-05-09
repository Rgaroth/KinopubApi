using KinopubApi.Processors.Interfaces;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Impls;

internal class AuthProcessor : BaseProcessor, IAuthProcessor
{
    internal AuthProcessor(HttpClient httpClient, string clientId, string clientSecret) : base(httpClient, clientId,
        clientSecret)
    {

    }

    public async Task<DeviceCodeResponse> GetDeviceCodeAsync()
    {
        var res =  await HttpClient.SendRequestAsync<DeviceCodeResponse>(HttpMethod.Post, "/oauth2/device",
            new Dictionary<string, string>
            {
                { "grant_type", "device_code" },
                { "client_id", ClientId },
                { "client_secret", ClientSecret },
            });

        return res;
    }

    public async Task<DeviceTokenResponse> GetDeviceTokenAsync(string deviceCode)
    {
        if (deviceCode == null)
        {
            throw new ArgumentNullException("deviceCode was null");
        }

        return await HttpClient.SendRequestAsync<DeviceTokenResponse>(HttpMethod.Post, "/oauth2/device",
            new Dictionary<string, string>
            {
                { "grant_type", "device_token" },
                { "client_id", ClientId },
                { "client_secret", ClientSecret },
                { "code", deviceCode },
            });
    }

    public async Task<UpdateDeviceTokenResponse> UpdateDeviceTokenAsync(string refreshToken)
    {
        if (refreshToken == null)
        {
            throw new ArgumentNullException("RefreshToken was null");
        }

        return await HttpClient.SendRequestAsync<UpdateDeviceTokenResponse>(HttpMethod.Post, "/oauth2/token",
            new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "client_id", ClientId },
                { "client_secret", ClientSecret },
                { "refresh_token", refreshToken },
            });
    }
}