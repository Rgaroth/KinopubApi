using FluentAssertions;
using KinopubApi.Tests.Base;

namespace KinopubApi.Tests;

public class DevicesTests : BaseTest
{
    [Test]
    public async Task GetDevicesAsync_IsNotNull_True()
    {
        var response = await _client.DevicesProcessor.GetDevicesAsync(_token);
        var deviceInfo = await _client.DevicesProcessor.GetDeviceInfoAsync(response.Devices.First().Id, _token);

        response.Devices.Any().Should().BeTrue();
        deviceInfo.Device.Should().NotBeNull();
    }

    [Test]
    public async Task GetCurrentDeviceInfoAsync_IsNotNull_True()
    {
        var response = await _client.DevicesProcessor.GetCurrentDeviceInfoAsync(_token);

        response.Device.Should().NotBeNull();
    }

    [Test]
    public async Task GetDeviceSettingsAsync_IsNotNull_True()
    {
        var device = await _client.DevicesProcessor.GetCurrentDeviceInfoAsync(_token); 
        var response = await _client.DevicesProcessor.GetDeviceSettingsAsync(device.Device.Id, _token);

        response.Settings.Should().NotBeNull();
    }
}
