using FluentAssertions;
using KinopubApi.Tests.Base;

namespace KinopubApi.Tests;

public class ReferencesTests : BaseTest
{
    [Test]
    public async Task GetServerLocationAsync_IsNotNull_True()
    {
        var response = await _client.ReferencesProcessor.GetServerLocationAsync(_token);
        
        response.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetVoiceoverAuthorAsync_IsNotNull_True()
    {
        var response = await _client.ReferencesProcessor.GetVoiceoverAuthorAsync(_token);

        response.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetVoiceoverTypeAsync_IsNotNull_True()
    {
        var response = await _client.ReferencesProcessor.GetVoiceoverTypeAsync(_token);

        response.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetStreamingTypeAsync_IsNotNull_True()
    {
        var response = await _client.ReferencesProcessor.GetStreamingTypeAsync(_token);

        response.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetVideoQualityAsync_IsNotNull_True()
    {
        var response = await _client.ReferencesProcessor.GetVideoQualityAsync(_token);

        response.Items.Any().Should().BeTrue();
    }
}