using KinopubApi.Processors.Interfaces;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Impls;

internal class BookmarksProcessor : BaseProcessor, IBookmarksProcessor
{
    public BookmarksProcessor(HttpClient httpClient, string clientId, string clientSecret) : base(httpClient, clientId, clientSecret)
    {
    }

    public async Task<GetBookmarksFoldersResponse> GetBookmarksFoldersAsync(CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<GetBookmarksFoldersResponse>(HttpMethod.Get, "/v1/bookmarks", token);
    }

    public async Task<GetItemsByBookmarkIdResponse> GetItemsByBookmarkIdAsync(long bookmarkId, CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<GetItemsByBookmarkIdResponse>(HttpMethod.Get, $"/v1/bookmarks/{bookmarkId}", token);
    }

    public async Task<CreateFolderResponse> CreateFolderAsync(string folderName, CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<CreateFolderResponse>(HttpMethod.Post, "/v1/bookmarks/create", token, 
            json: new { title = folderName });
    }

    public async Task<HttpResponseMessage> AddItemToFolder(long itemId, long folderId, CancellationToken token)
    {
        return await HttpClient.SendRequestAsync(HttpMethod.Post, "/v1/bookmarks/add", token,
           json: new { folder = folderId, item = itemId });
    }

    public async Task<HttpResponseMessage> RemoveFolderAsync(long folderId, CancellationToken token)
    {
        return await HttpClient.SendRequestAsync<HttpResponseMessage>(HttpMethod.Post, "/v1/bookmarks/remove-folder", token,
            json: new { folder = folderId });
    }

    public async Task<HttpResponseMessage> RemoveItemFromFolder(long itemId, CancellationToken token, long? folderId = null)
    {
        return await HttpClient.SendRequestAsync(HttpMethod.Post, "/v1/bookmarks/remove-item", token,
           json: new { folder = folderId, item = itemId });
    }
}
