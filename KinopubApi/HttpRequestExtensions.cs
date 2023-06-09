﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace KinopubApi;

internal static class HttpRequestExtensions
{
    internal static async Task<T> SendRequestAsync<T>(this HttpClient httpClient, 
        HttpMethod method, 
        string uri,
        CancellationToken token,
        Dictionary<string, string> parameters = null,
        object json = null)
    {
        uri = parameters != null && parameters.Any()
            ? $"{uri}?{string.Join('&', parameters.Select(x => $"{x.Key}={x.Value}"))}"
            : uri;

        var request = new HttpRequestMessage(method, uri);

        if (json != null)
        {
            request.Content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
        }

        var response = await httpClient.SendAsync(request, token);
        var content = await response.Content.ReadAsStringAsync(token);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(content);
        }


        return JsonConvert.DeserializeObject<T>(content);
    }

    internal static async Task<HttpResponseMessage> SendRequestAsync(this HttpClient httpClient, 
        HttpMethod method, 
        string uri,
        CancellationToken token,
        Dictionary<string, string> parameters = null,
        object json = null)
    {
        uri = parameters != null
            ? $"{uri}?{string.Join('&', parameters.Select(x => $"{x.Key}={x.Value}"))}"
            : uri;

        var request = new HttpRequestMessage(method, uri);

        if (json != null)
        {
            request.Content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
        }

        return await httpClient.SendAsync(request, token);
    }

    internal static Dictionary<string, string> CreateParameters(params (string Key, object Value)[] pairs)
    {
        return pairs
            .Where(x => x.Key != null && x.Value != null)
            .ToDictionary(x => x.Key, d => d.Value.ToString());
    }
}