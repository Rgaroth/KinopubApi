using System.Net.Http;
using KinopubApi.Exceptions;
using KinopubApi.Responses;
using KinopubApi.Results;
using Newtonsoft.Json;

namespace KinopubApi.Client
{
    public class KinopubClient : IKinopubClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        public string Token { get; set; }
        
        private PeriodicTimer _authTimer;

        public bool IsAuthenticated { get; private set; }

        public KinopubClient(HttpClient httpClient, string clientId, string clientSecret)
        {
            _httpClient = httpClient;
            _clientId = clientId;
            _clientSecret = clientSecret;

            IsAuthenticated = false;
        }

        public async Task<IKinopubResult<string>> GetDeviceCodeAsync()
        {
            IKinopubResult<string> result = new KinopubResult<string>();

            try
            {
                var deviceResponse = await SendRequestAsync<DeviceResponse>(HttpMethod.Post, "/oauth2/device",
                    new Dictionary<string, string>
                    {
                        { "grant_type", "device_code" },
                        { "client_id", _clientId },
                        { "client_secret", _clientSecret },
                    });

                _authTimer = new PeriodicTimer(TimeSpan.FromSeconds(deviceResponse.Interval));
                _ = CheckDeviceAuthJobAsync(deviceResponse.Code);

                return result.WithData(deviceResponse.UserCode);
            }
            catch (HttpRequestException ex)
            {
                return result.WithError($"Error while request {nameof(GetDeviceCodeAsync)}: {ex}");
            }
        }

        private async Task CheckDeviceAuthJobAsync(string deviceCode)
        {
            var token = new CancellationTokenSource(TimeSpan.Parse("00:01:00")).Token;

            while (await _authTimer.WaitForNextTickAsync(token) || !token.IsCancellationRequested)
            {
                try
                {
                    var response = await SendRequestAsync<DeviceTokenReponse>(HttpMethod.Post, "/oauth2/device",
                        new Dictionary<string, string>
                        {
                            { "grant_type", "device_token" },
                            { "client_id", _clientId },
                            { "client_secret", _clientSecret },
                            { "code", deviceCode },
                        });

                    Token = response.AccessToken;

                }
                catch (HttpRequestException)
                {
                    continue;
                }

                IsAuthenticated = true;
                break;
            }

            _authTimer.Dispose();

            if (!IsAuthenticated)
            {
                throw new ClientAuthException("Timeout");
            }
        }

        private async Task<T> SendRequestAsync<T>(HttpMethod method, string uri, Dictionary<string, string> parameters = null)
        {
            uri = parameters != null
                ? $"{uri}?{string.Join('&', parameters.Select(x => $"{x.Key}={x.Value}"))}"
                : uri;

            var request = new HttpRequestMessage(method, uri);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }

        private async Task<HttpResponseMessage> SendRequestAsync(HttpMethod method, string uri, Dictionary<string, string> parameters = null)
        {
            uri = parameters != null
                ? $"{uri}?{string.Join('&', parameters.Select(x => $"{x.Key}={x.Value}"))}"
                : uri;

            var request = new HttpRequestMessage(method, uri);

            return await _httpClient.SendAsync(request);
        }
    }
}