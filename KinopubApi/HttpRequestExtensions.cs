using Newtonsoft.Json;
using System.Text;

namespace KinopubApi;

internal static class HttpRequestExtensions
{
    internal static async Task<T> SendRequestAsync<T>(this HttpClient httpClient, 
        HttpMethod method, 
        string uri, 
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

        var response = await httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(content);
        }


        return JsonConvert.DeserializeObject<T>(content);
    }

    internal static async Task<HttpResponseMessage> SendRequestAsync(this HttpClient httpClient, HttpMethod method, string uri, Dictionary<string, string> parameters = null)
    {
        uri = parameters != null
            ? $"{uri}?{string.Join('&', parameters.Select(x => $"{x.Key}={x.Value}"))}"
            : uri;

        var request = new HttpRequestMessage(method, uri);

        return await httpClient.SendAsync(request);
    }
}