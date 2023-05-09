using FluentAssertions;
using KinopubApi.Client;
using KinopubApi.Tests.Base;

namespace KinopubApi.Tests
{
    public class Tests : BaseTest
    {
        private KinopubClient _client;
        private string _accessToken;

        protected override void OnInitialize(HttpClient httpClient, ApiClientSettings settings)
        {
            _client = new KinopubClient(httpClient, settings.ClientId, settings.ClientSecret);
            _accessToken = settings.TestAccessToken;
        }

        [Test]
        public async Task GetDeviceCode_IsNotNull_True()
        {
            var response = await _client.GetDeviceCodeAsync();

            response.IsSuccess.Should().BeTrue();
            response.Data.Should().NotBeNullOrEmpty();

            System.Diagnostics.Debug.WriteLine($"Code: {response.Data}");

            var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            var token = new CancellationTokenSource(TimeSpan.Parse("00:01:00")).Token;

            while (await timer.WaitForNextTickAsync(token) || !token.IsCancellationRequested)
            {
                if (_client.IsAuthenticated)
                {
                    break;
                }
            }

            _client.AccessToken.Should().NotBeNullOrEmpty();
            System.Diagnostics.Debug.WriteLine($"Token: {_client.AccessToken}");
        }
    }
}