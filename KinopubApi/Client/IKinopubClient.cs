using KinopubApi.Processors.Impls;
using KinopubApi.Processors.Interfaces;
using KinopubApi.Results;
using System.Net.Http;

namespace KinopubApi.Client;

public interface IKinopubClient
{
    bool IsAuthenticated { get; }
    string AccessToken { get; }
    string RefreshToken { get; }

    IAuthProcessor AuthProcessor { get; }
    IUserProcessor UserProcessor { get; }
    IReferencesProcessor ReferencesProcessor { get; }
    IDevicesProcessor DevicesProcessor { get; }
    IVideoContentProcessor VideoContentProcessor { get; }
    ITvProcessor TvProcessor { get; }

    Task<IKinopubResult<string>> GetDeviceCodeAsync();
}