﻿using KinopubApi.Models;
using KinopubApi.Processors.Interfaces;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Impls;

internal class AuthProcessor : BaseProcessor, IAuthProcessor
{
    internal AuthProcessor(HttpClient httpClient, string clientId, string clientSecret) : base(httpClient, clientId,
        clientSecret)
    {

    }

    public async Task<HttpResponseMessage> DeviceNotify(DeviceInfo deviceInfo, CancellationToken token)
    {
        return await HttpClient.SendRequestAsync(HttpMethod.Post, "/v1/device/notify", token,
            new Dictionary<string, string>
            {
                { "title", deviceInfo.Title },
                { "hardware", deviceInfo.Hardware },
                { "software", deviceInfo.Software }
            });
    }

    public async Task<DeviceCodeResponse> GetDeviceCodeAsync(CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<DeviceCodeResponse>(HttpMethod.Post, "/oauth2/device", token,
            HttpRequestExtensions.CreateParameters(
                ("grant_type", "device_code"),
                ("client_id", ClientId),
                ("client_secret", ClientSecret)));
    }

    public async Task<DeviceTokenResponse> GetDeviceTokenAsync(string deviceCode, CancellationToken token)
    {
        if (deviceCode == null)
        {
            throw new ArgumentNullException("deviceCode was null");
        }

        return await HttpClient.SendRequestAsync<DeviceTokenResponse>(HttpMethod.Post, "/oauth2/device", token,
           HttpRequestExtensions.CreateParameters(
                ("grant_type", "device_token"),
                ("client_id", ClientId),
                ("client_secret", ClientSecret),
                ("code", deviceCode)));
    }

    public async Task<UpdateDeviceTokenResponse> UpdateDeviceTokenAsync(string refreshToken, CancellationToken token)
    {
        if (refreshToken == null)
        {
            throw new ArgumentNullException("RefreshToken was null");
        }

        return await HttpClient.SendRequestAsync<UpdateDeviceTokenResponse>(HttpMethod.Post, "/oauth2/token", token,
            HttpRequestExtensions.CreateParameters(
                ("grant_type", "refresh_token"),
                ("client_id", ClientId),
                ("client_secret", ClientSecret),
                ("refresh_token", refreshToken)));
    }
}