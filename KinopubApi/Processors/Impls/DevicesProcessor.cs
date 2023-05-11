using KinopubApi.Processors.Interfaces;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Impls;

internal class DevicesProcessor : BaseProcessor, IDevicesProcessor
{
    public DevicesProcessor(HttpClient httpClient, string clientId, string clientSecret) : base(httpClient, clientId, clientSecret)
    {
    }

    public async Task<GetDevicesResponse> GetDevicesAsync()
    {
        return await HttpClient.SendRequestAsync<GetDevicesResponse>(HttpMethod.Get, "/v1/device");
    }

    public async Task<HttpResponseMessage> UnlinkCurrentDevice()
    {
        return await HttpClient.SendRequestAsync(HttpMethod.Post, "/v1/device/unlink");
    }

    public async Task<HttpResponseMessage> RemoveDevice(int deviceId)
    {
        return await HttpClient.SendRequestAsync(HttpMethod.Post, "/v1/device/remove",
            HttpRequestExtensions.CreateParameters(("id", deviceId)));
    }

    public async Task<GetDeviceInfoResponse> GetDeviceInfoAsync(long deviceId)
    {
        return await HttpClient.SendRequestAsync<GetDeviceInfoResponse>(HttpMethod.Get, $"/v1/device/{deviceId}");
    }

    public async Task<GetDeviceInfoResponse> GetCurrentDeviceInfoAsync()
    {
        return await HttpClient.SendRequestAsync<GetDeviceInfoResponse>(HttpMethod.Get, $"/v1/device/info");
    }

    public async Task<GetDeviceSettingsResponse> GetDeviceSettingsAsync(long deviceId)
    {
        return await HttpClient.SendRequestAsync<GetDeviceSettingsResponse>(HttpMethod.Get, $"/v1/device/{deviceId}/settings");
    }

    public async Task<GetDeviceInfoResponse> SetDeviceSettingsAsync(long deviceId, GetDevicesResponse.Settings settings)
    {
        return await HttpClient.SendRequestAsync<GetDeviceInfoResponse>(HttpMethod.Get, $"/v1/device/{deviceId}/settings", json: settings);
    }
}