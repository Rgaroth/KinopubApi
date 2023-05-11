using FluentAssertions;
using KinopubApi.Tests.Base;

namespace KinopubApi.Tests;

public class BookmarksTests : BaseTest
{
    private long _bookmarkId = 1473940; // тут у всех своя должна быть
    private long _movieId = 89944;

    [Test]
    public async Task GetBookmarks_IsSuccess_True()
    {
        var response = await _client.BookmarksProcessor.GetBookmarksFoldersAsync();
        response.Status.Should().Be(200);
    }

    [Test]
    public async Task GetBookmarksItems_IsSuccess_True()
    {
        var response = await _client.BookmarksProcessor.GetItemsByBookmarkIdAsync(_bookmarkId);
        response.Status.Should().Be(200);
    }

    [Test]
    public async Task CreateRemoveFolderAsync_IsSuccess_True()
    {
        var response = await _client.BookmarksProcessor.CreateFolderAsync("TEST_FOLDER_BOOKMARKS");
        response.Status.Should().Be(200);

        var responseAdding = await _client.BookmarksProcessor.AddItemToFolder(_movieId, response.Folder.Id);
        responseAdding.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        var responseRemoving = await _client.BookmarksProcessor.RemoveItemFromFolder(_movieId);
        responseRemoving.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        var res = await _client.BookmarksProcessor.RemoveFolderAsync(response.Folder.Id);
        res.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }
}
