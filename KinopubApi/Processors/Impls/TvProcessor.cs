using KinopubApi.Processors.Interfaces;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Impls;

internal class TvProcessor : BaseProcessor, ITvProcessor
{
    public TvProcessor(HttpClient httpClient, string clientId, string clientSecret) : base(httpClient, clientId, clientSecret)
    {
    }

    public async Task<GetTvChannelsResponse> GetTvChannelsAsync()
    {
        return await HttpClient.SendRequestAsync<GetTvChannelsResponse>(HttpMethod.Get, "/v1/tv");
    }
}
