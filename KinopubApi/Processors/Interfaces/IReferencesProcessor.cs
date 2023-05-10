using KinopubApi.Responses;

namespace KinopubApi.Processors.Interfaces;

public interface IReferencesProcessor
{
    Task<GetServerLocationResponse> GetServerLocationAsync();

    Task<GetStreamingTypeResponse> GetStreamingTypeAsync();

    Task<GetVoiceoverTypeResponse> GetVoiceoverTypeAsync();

    Task<GetVoiceoverAuthorResponse> GetVoiceoverAuthorAsync();

    Task<GetVideoQualityResponse> GetVideoQualityAsync();
}
