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
        private PeriodicTimer _authTimer;

        public bool IsAuthenticated { get; private set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public IAuthProcessor AuthProcessor { get; private set; }

        public KinopubClient(HttpClient httpClient, string clientId, string clientSecret)
        {
            IsAuthenticated = false;
            InitializeProcessors(httpClient, clientId, clientSecret);
        }

        public KinopubClient(string accessToken, string refreshToken, HttpClient httpClient, string clientId, string clientSecret)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            IsAuthenticated = true;

            InitializeProcessors(httpClient, clientId, clientSecret);
        }

        private void InitializeProcessors(HttpClient httpClient, string clientId, string clientSecret)
        {
            AuthProcessor = new AuthProcessor(httpClient, clientId, clientSecret);
        }

        #region AUTH
        public async Task<IKinopubResult<string>> GetDeviceCodeAsync()
        {
            IKinopubResult<string> result = new KinopubResult<string>();
            
            if (IsAuthenticated)
            {
                return result.WithError("Client is authenticated!");
            }

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
                    AccessToken = response.AccessToken;
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