using KinopubApi.Processors.Interfaces;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Impls;

internal class ReferencesProcessor : BaseProcessor, IReferencesProcessor
{
    public ReferencesProcessor(HttpClient httpClient, string clientId, string clientSecret) : base(httpClient, clientId, clientSecret)
    {
    }

    public async Task<GetServerLocationResponse> GetServerLocationAsync(CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<GetServerLocationResponse>(HttpMethod.Get, "/v1/references/server-location", token);
    }

    public async Task<GetStreamingTypeResponse> GetStreamingTypeAsync(CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<GetStreamingTypeResponse>(HttpMethod.Get, "/v1/references/streaming-type", token);
    }

    public async Task<GetVoiceoverTypeResponse> GetVoiceoverTypeAsync(CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<GetVoiceoverTypeResponse>(HttpMethod.Get, "/v1/references/voiceover-type", token);
    }

    public async Task<GetVoiceoverAuthorResponse> GetVoiceoverAuthorAsync(CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<GetVoiceoverAuthorResponse>(HttpMethod.Get, "/v1/references/voiceover-author", token);
    }

    public async Task<GetVideoQualityResponse> GetVideoQualityAsync(CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<GetVideoQualityResponse>(HttpMethod.Get, "/v1/references/video-quality", token);
    }
}
