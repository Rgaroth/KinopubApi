using FluentAssertions;
using KinopubApi.Client;
using KinopubApi.Tests.Base;

namespace KinopubApi.Tests;

public class Tests : BaseTest
{
    [Test]
    public async Task GetDeviceCode_IsNotNull_True()
    {
        var response = await _notAuthClient.GetDeviceCodeAsync();

        response.IsSuccess.Should().BeTrue();
        response.Data.Should().NotBeNullOrEmpty();

        System.Diagnostics.Debug.WriteLine($"Code: {response.Data}");

        var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
        var token = new CancellationTokenSource(TimeSpan.Parse("00:01:00")).Token;

        while (await timer.WaitForNextTickAsync(token) || !token.IsCancellationRequested)
        {
            if (_notAuthClient.IsAuthenticated)
            {
                break;
            }
        }

        _notAuthClient.AccessToken.Should().NotBeNullOrEmpty();
        System.Diagnostics.Debug.WriteLine($"Token: {_notAuthClient.AccessToken}");
    }

    [Test]
    public async Task GetUserAsync_IsNotNull_True()
    {
        var response = await _client.UserProcessor.GetUserAsync();

        response.User.Should().NotBeNull();
        response.User.Username.Should().NotBeNullOrEmpty();
    }
}