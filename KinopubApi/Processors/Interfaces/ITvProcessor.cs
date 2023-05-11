using KinopubApi.Responses;

namespace KinopubApi.Processors.Interfaces;

public interface ITvProcessor
{
    Task<GetTvChannelsResponse> GetTvChannelsAsync();
}
