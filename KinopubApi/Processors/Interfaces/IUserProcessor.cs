using KinopubApi.Responses;

namespace KinopubApi.Processors.Interfaces;

public interface IUserProcessor
{
    Task<GetUserResponse> GetUserAsync();
}
