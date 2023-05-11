using KinopubApi.Processors.Interfaces;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Impls;

internal class DevicesProcessor : BaseProcessor, IDevicesProcessor
{
    public DevicesProcessor(HttpClient httpClient, string clientId, string clientSecret) : base(httpClient, clientId, clientSecret)
    {
    }

    public async Task<GetDevicesResponse> GetDevicesAsync(CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<GetDevicesResponse>(HttpMethod.Get, "/v1/device", token);
    }

    public async Task<HttpResponseMessage> UnlinkCurrentDevice(CancellationToken token)
    {
        return await HttpClient.SendRequestAsync(HttpMethod.Post, "/v1/device/unlink", token);
    }

    public async Task<HttpResponseMessage> RemoveDevice(int deviceId, CancellationToken token)
    {
        return await HttpClient.SendRequestAsync(HttpMethod.Post, "/v1/device/remove", token,
            HttpRequestExtensions.CreateParameters(("id", deviceId)));
    }

    public async Task<GetDeviceInfoResponse> GetDeviceInfoAsync(long deviceId, CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<GetDeviceInfoResponse>(HttpMethod.Get, $"/v1/device/{deviceId}", token);
    }

    public async Task<GetDeviceInfoResponse> GetCurrentDeviceInfoAsync(CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<GetDeviceInfoResponse>(HttpMethod.Get, $"/v1/device/info", token);
    }

    public async Task<GetDeviceSettingsResponse> GetDeviceSettingsAsync(long deviceId, CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<GetDeviceSettingsResponse>(HttpMethod.Get, $"/v1/device/{deviceId}/settings", token);
    }

    public async Task<GetDeviceInfoResponse> SetDeviceSettingsAsync(long deviceId, GetDevicesResponse.Settings settings, CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<GetDeviceInfoResponse>(HttpMethod.Get, $"/v1/device/{deviceId}/settings", token, 
            json: settings);
    }
}