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
        var items = await _client.VideoContentProcessor.GetItemsAsync(_token, director: "ари астер", letter: "со");

        items.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetContentTypes_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetContentTypesAsync(_token);

        items.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task Search_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.SearchAsync("терми", _token, type: Enums.GenreType.Movie);

        items.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetSimilar_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetSimilarAsync(_serialId, _token);

        items.Status.Should().Be(200);
    }

    [Test]
    public async Task GetContentGenres_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetContentGenresAsync(_token);

        items.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetСountries_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetСountriesAsync(_token);

        items.Items.Any().Should().BeTrue();
    }
    [Test]
    public async Task VoteForVideo_IsNotNull_True()
    {
        var response = await _client.VideoContentProcessor.VoteForVideoAsync(_movieId, true, _token);

        response.Should().NotBeNull();
    }

    [Test]
    public async Task GetSubtitlesAndVideos_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetSubtitlesAndVideosAsync(100, _token);

        items.Subtitles.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetTrailer_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetTrailerAsync(_movieId, _token);

        items.Trailer.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetItem_IsNotNull_True()
    {
        var itemSerial = await _client.VideoContentProcessor.GetItemAsync(_serialId, _token);
        var itemMovie = await _client.VideoContentProcessor.GetItemAsync(_movieId, _token);

        itemSerial?.Item?.Seasons?.FirstOrDefault()?.Episodes?.FirstOrDefault().Should().NotBeNull();
        itemMovie?.Item?.Videos?.FirstOrDefault()?.Files?.FirstOrDefault().Should().NotBeNull();
    }

    [Test]
    public async Task GetFresh_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetFreshAsync(Enums.GenreType.Movie, _token);

        items.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetPopular_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetPopularAsync(Enums.GenreType.Movie, _token);

        items.Items.Any().Should().BeTrue();
    }

    [Test]
    public async Task GetHot_IsNotNull_True()
    {
        var items = await _client.VideoContentProcessor.GetHotAsync(Enums.GenreType.Movie, _token);

        items.Items.Any().Should().BeTrue();
    }
}
