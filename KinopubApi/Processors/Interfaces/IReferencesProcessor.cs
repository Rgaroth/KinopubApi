using KinopubApi.Responses;

namespace KinopubApi.Processors.Interfaces;

public interface IReferencesProcessor
{
    Task<GetServerLocationResponse> GetServerLocationAsync(CancellationToken token);

    Task<GetStreamingTypeResponse> GetStreamingTypeAsync(CancellationToken token);

    Task<GetVoiceoverTypeResponse> GetVoiceoverTypeAsync(CancellationToken token);

    Task<GetVoiceoverAuthorResponse> GetVoiceoverAuthorAsync(CancellationToken token);

    Task<GetVideoQualityResponse> GetVideoQualityAsync(CancellationToken token);
}
