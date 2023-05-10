using FluentAssertions;
using KinopubApi.Tests.Base;

namespace KinopubApi.Tests;

public class ReferencesTests : BaseTest
{
    [Test]
    public async Task GetServerLocationAsync_IsNotNull_True()
    {
        var response = await _client.ReferencesProcessor.GetServerLocationAsync();
        
        response.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetVoiceoverAuthorAsync_IsNotNull_True()
    {
        var response = await _client.ReferencesProcessor.GetVoiceoverAuthorAsync();

        response.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetVoiceoverTypeAsync_IsNotNull_True()
    {
        var response = await _client.ReferencesProcessor.GetVoiceoverTypeAsync();

        response.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetStreamingTypeAsync_IsNotNull_True()
    {
        var response = await _client.ReferencesProcessor.GetStreamingTypeAsync();

        response.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetVideoQualityAsync_IsNotNull_True()
    {
        var response = await _client.ReferencesProcessor.GetVideoQualityAsync();

        response.Items.Any().Should().BeTrue();
    }
}