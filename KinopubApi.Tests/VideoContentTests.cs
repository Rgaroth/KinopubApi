using FluentAssertions;
using KinopubApi.Tests.Base;

namespace KinopubApi.Tests;

public class VideoContentTests : BaseTest
{
    private long _serialId = 21263;
    private long _movieId = 89944;
    [Test]
    public async Task GetItems_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetItemsAsync(director: "ари астер", letter: "со");

        items.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetContentTypes_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetContentTypesAsync();

        items.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task Search_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.SearchAsync("терми", type: Enums.GenreType.Movie);

        items.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetSimilar_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetSimilarAsync(_serialId);

        items.Status.Should().Be(200);
    }

    [Test]
    public async Task GetContentGenres_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetContentGenresAsync();

        items.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetСountries_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetСountriesAsync();

        items.Items.Any().Should().BeTrue();
    }
    [Test]
    public async Task VoteForVideo_IsNotNull_True()
    {
        var response = await _client.VideoContentProcessor.VoteForVideoAsync(_movieId, true);

        response.Should().NotBeNull();
    }

    [Test]
    public async Task GetSubtitlesAndVideos_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetSubtitlesAndVideosAsync(100);

        items.Subtitles.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetTrailer_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetTrailerAsync(_movieId);

        items.Trailer.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetItem_IsNotNull_True()
    {
        var itemSerial = await _client.VideoContentProcessor.GetItemAsync(_serialId);
        var itemMovie = await _client.VideoContentProcessor.GetItemAsync(_movieId);

        itemSerial?.Item?.Seasons?.FirstOrDefault()?.Episodes?.FirstOrDefault().Should().NotBeNull();
        itemMovie?.Item?.Videos?.FirstOrDefault()?.Files?.FirstOrDefault().Should().NotBeNull();
    }

    [Test]
    public async Task GetFresh_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetFreshAsync(Enums.GenreType.Movie);

        items.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetPopular_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetPopularAsync(Enums.GenreType.Movie);

        items.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetHot_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetHotAsync(Enums.GenreType.Movie);

        items.Items.Any().Should().BeTrue();
    }
}
