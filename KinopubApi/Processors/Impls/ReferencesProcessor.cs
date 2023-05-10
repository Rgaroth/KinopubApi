using KinopubApi.Processors.Interfaces;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Impls;

internal class ReferencesProcessor : BaseProcessor, IReferencesProcessor
{
    public ReferencesProcessor(HttpClient httpClient, string clientId, string clientSecret) : base(httpClient, clientId, clientSecret)
    {
    }

    public async Task<GetServerLocationResponse> GetServerLocationAsync()
    {
        return await HttpClient.SendRequestAsync<GetServerLocationResponse>(HttpMethod.Get, "/v1/references/server-location");
    }

    public async Task<GetStreamingTypeResponse> GetStreamingTypeAsync()
    {
        return await HttpClient.SendRequestAsync<GetStreamingTypeResponse>(HttpMethod.Get, "/v1/references/streaming-type");
    }

    public async Task<GetVoiceoverTypeResponse> GetVoiceoverTypeAsync()
    {
        return await HttpClient.SendRequestAsync<GetVoiceoverTypeResponse>(HttpMethod.Get, "/v1/references/voiceover-type");
    }

    public async Task<GetVoiceoverAuthorResponse> GetVoiceoverAuthorAsync()
    {
        return await HttpClient.SendRequestAsync<GetVoiceoverAuthorResponse>(HttpMethod.Get, "/v1/references/voiceover-author");
    }

    public async Task<GetVideoQualityResponse> GetVideoQualityAsync()
    {
        return await HttpClient.SendRequestAsync<GetVideoQualityResponse>(HttpMethod.Get, "/v1/references/video-quality");
    }
}
