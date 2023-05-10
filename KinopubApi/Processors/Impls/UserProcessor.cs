using KinopubApi.Processors.Interfaces;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Impls
{
    internal class UserProcessor : BaseProcessor, IUserProcessor
    {
        public UserProcessor(HttpClient httpClient, string clientId, string clientSecret) : base(httpClient, clientId, clientSecret)
        {
        }

        public async Task<GetUserResponse> GetUserAsync()
        {
            return await HttpClient.SendRequestAsync<GetUserResponse>(HttpMethod.Post, "/v1/user");
        }
    }
}
