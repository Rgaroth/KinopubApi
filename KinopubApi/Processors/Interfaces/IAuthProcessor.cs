using KinopubApi.Responses;

namespace KinopubApi.Processors.Interfaces;

public interface IAuthProcessor
{
    Task<DeviceCodeResponse> GetDeviceCodeAsync();
    Task<DeviceTokenResponse> GetDeviceTokenAsync(string deviceCode);
    Task<UpdateDeviceTokenResponse> UpdateDeviceTokenAsync(string refreshToken);
}