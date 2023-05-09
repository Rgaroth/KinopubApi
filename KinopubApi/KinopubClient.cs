using System.Net.Http;

namespace KinopubApi
{
    public class KinopubClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;

        internal KinopubClient(HttpClient httpClient, string clientId, string clientSecret)
        {
            _httpClient = httpClient;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }
    }
}