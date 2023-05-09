using KinopubApi.Processors.Interfaces;

namespace KinopubApi.Processors.Impls;

internal class DevicesProcessor : BaseProcessor, IDevicesProcessor
{
    public DevicesProcessor(HttpClient httpClient, string clientId, string clientSecret) : base(httpClient, clientId, clientSecret)
    {
    }


}