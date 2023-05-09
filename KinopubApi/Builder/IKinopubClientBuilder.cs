using KinopubApi.Client;

namespace KinopubApi.Builder;

public interface IKinopubClientBuilder
{
    IKinopubClientBuilder AddApiKeys(string clientId, string clientSecret);
    IKinopubClientBuilder UseHttpClient(HttpClient httpClient);
    IKinopubClientBuilder UseHttpClientHandler(HttpClientHandler httpClientHandler);
    IKinopubClientBuilder UseToken(string accessToken, string refreshToken);
    IKinopubClient Build();
}