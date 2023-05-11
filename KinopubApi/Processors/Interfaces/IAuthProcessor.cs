using KinopubApi.Models;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Interfaces;

public interface IAuthProcessor
{
    Task<DeviceCodeResponse> GetDeviceCodeAsync(CancellationToken token);
    Task<DeviceTokenResponse> GetDeviceTokenAsync(string deviceCode, CancellationToken token);
    Task<UpdateDeviceTokenResponse> UpdateDeviceTokenAsync(string refreshToken, CancellationToken token);
    Task<HttpResponseMessage> DeviceNotify(DeviceInfo deviceInfo, CancellationToken token);
}