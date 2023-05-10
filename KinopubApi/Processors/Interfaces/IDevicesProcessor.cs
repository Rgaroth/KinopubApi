using KinopubApi.Responses;

namespace KinopubApi.Processors.Interfaces;

public interface IDevicesProcessor
{
    Task<GetDevicesResponse> GetDevicesAsync();

    Task<HttpResponseMessage> UnlinkCurrentDevice();

    Task<HttpResponseMessage> RemoveDevice(int deviceId);

    Task<GetDeviceInfoResponse> GetDeviceInfoAsync(long deviceId);

    Task<GetDeviceInfoResponse> GetCurrentDeviceInfoAsync();

    Task<GetDeviceSettingsResponse> GetDeviceSettingsAsync(long deviceId);

    Task<GetDeviceInfoResponse> SetDeviceSettingsAsync(long deviceId, GetDevicesResponse.Settings settings);
}