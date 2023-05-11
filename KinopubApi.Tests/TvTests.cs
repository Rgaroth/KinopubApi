using FluentAssertions;
using KinopubApi.Tests.Base;

namespace KinopubApi.Tests;

public class TvTests : BaseTest
{
    [Test]
    public async Task GetTvChannelsAsync_IsNotNull_True()
    {
        var response = await _client.TvProcessor.GetTvChannelsAsync(_token);

        response.Channels.Any().Should().BeTrue();
    }
}
