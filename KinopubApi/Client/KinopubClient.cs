using System.Net.Http;
using KinopubApi.Exceptions;
using KinopubApi.Models;
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
        private HttpClient _httpClient;
        private string _clientId;
        private string _clientSecret;

        public bool IsAuthenticated { get; private set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public IAuthProcessor AuthProcessor { get; private set; }
        public IUserProcessor UserProcessor { get; private set; }
        public IReferencesProcessor ReferencesProcessor { get; private set; }

        public KinopubClient(HttpClient httpClient, string clientId, string clientSecret)
        {
            AuthProcessor = new AuthProcessor(httpClient, clientId, clientSecret);

            _clientId = clientId;
            _clientSecret = clientSecret;
            _httpClient = httpClient;

            IsAuthenticated = false;
        }

        public KinopubClient(string accessToken, string refreshToken, HttpClient httpClient, string clientId, string clientSecret)
        {
            _httpClient = httpClient;
            _clientId = clientId;
            _clientSecret = clientSecret;

            AccessToken = accessToken;
            RefreshToken = refreshToken;

            IsAuthenticated = true;
            AuthProcessor = new AuthProcessor(httpClient, clientId, clientSecret);
            InitializeProcessors(httpClient, clientId, clientSecret);
        }

        private void InitializeProcessors(HttpClient httpClient, string clientId, string clientSecret)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

            UserProcessor = new UserProcessor(httpClient, clientId, clientSecret);
            ReferencesProcessor = new ReferencesProcessor(httpClient, clientId, clientSecret);
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

                InitializeProcessors(_httpClient, _clientId, _clientSecret);
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