using KinopubApi.Processors.Interfaces;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Impls;

internal class BookmarksProcessor : BaseProcessor, IBookmarksProcessor
{
    public BookmarksProcessor(HttpClient httpClient, string clientId, string clientSecret) : base(httpClient, clientId, clientSecret)
    {
    }

    public async Task<GetBookmarksFoldersResponse> GetBookmarksFoldersAsync()
    {
        return await HttpClient.SendRequestAsync<GetBookmarksFoldersResponse>(HttpMethod.Get, "/v1/bookmarks");
    }

    public async Task<GetItemsByBookmarkIdResponse> GetItemsByBookmarkIdAsync(long bookmarkId)
    {
        return await HttpClient.SendRequestAsync<GetItemsByBookmarkIdResponse>(HttpMethod.Get, $"/v1/bookmarks/{bookmarkId}");
    }

    public async Task<CreateFolderResponse> CreateFolderAsync(string folderName)
    {
        return await HttpClient.SendRequestAsync<CreateFolderResponse>(HttpMethod.Post, "/v1/bookmarks/create", 
            json: new { title = folderName });
    }

    public async Task<HttpResponseMessage> AddItemToFolder(long itemId, long folderId)
    {
        return await HttpClient.SendRequestAsync(HttpMethod.Post, "/v1/bookmarks/add",
           json: new { folder = folderId, item = itemId });
    }

    public async Task<HttpResponseMessage> RemoveFolderAsync(long folderId)
    {
        return await HttpClient.SendRequestAsync<HttpResponseMessage>(HttpMethod.Post, "/v1/bookmarks/remove-folder",
            json: new { folder = folderId });
    }

    public async Task<HttpResponseMessage> RemoveItemFromFolder(long itemId, long? folderId = null)
    {
        return await HttpClient.SendRequestAsync(HttpMethod.Post, "/v1/bookmarks/remove-item",
           json: new { folder = folderId, item = itemId });
    }
}
