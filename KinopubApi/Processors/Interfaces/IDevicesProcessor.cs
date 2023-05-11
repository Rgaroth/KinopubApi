using KinopubApi.Responses;

namespace KinopubApi.Processors.Interfaces;

public interface IDevicesProcessor
{
    Task<GetDevicesResponse> GetDevicesAsync(CancellationToken token);

    Task<HttpResponseMessage> UnlinkCurrentDevice(CancellationToken token);

    Task<HttpResponseMessage> RemoveDevice(int deviceId, CancellationToken token);

    Task<GetDeviceInfoResponse> GetDeviceInfoAsync(long deviceId, CancellationToken token);

    Task<GetDeviceInfoResponse> GetCurrentDeviceInfoAsync(CancellationToken token);

    Task<GetDeviceSettingsResponse> GetDeviceSettingsAsync(long deviceId, CancellationToken token);

    Task<GetDeviceInfoResponse> SetDeviceSettingsAsync(long deviceId, GetDevicesResponse.Settings settings, CancellationToken token);
}