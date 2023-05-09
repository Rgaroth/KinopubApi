using System.Net.Http;
using KinopubApi.Exceptions;
using KinopubApi.Processors.Impls;
using KinopubApi.Processors.Interfaces;
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
        private PeriodicTimer _authTimer;

        public bool IsAuthenticated { get; private set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public IAuthProcessor AuthProcessor { get; }

        public KinopubClient(HttpClient httpClient, string clientId, string clientSecret)
        {
            _httpClient = httpClient;
            _clientId = clientId;
            _clientSecret = clientSecret;

            IsAuthenticated = false;

            AuthProcessor = new AuthProcessor(httpClient, clientId, clientSecret);
        }

        #region AUTH
        public async Task<IKinopubResult<string>> GetDeviceCodeAsync()
        {
            IKinopubResult<string> result = new KinopubResult<string>();

            try
            {
                var deviceResponse = await AuthProcessor.GetDeviceCodeAsync();

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
                    var response = await AuthProcessor.GetDeviceTokenAsync(deviceCode);
                    Token = response.AccessToken;
                    RefreshToken = response.RefreshToken;

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
        #endregion
    }
}