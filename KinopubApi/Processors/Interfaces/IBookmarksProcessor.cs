using KinopubApi.Responses;

namespace KinopubApi.Processors.Interfaces;

public interface IBookmarksProcessor
{
    Task<HttpResponseMessage> AddItemToFolder(long itemId, long folderId, CancellationToken token);
    Task<CreateFolderResponse> CreateFolderAsync(string folderName, CancellationToken token);
    Task<GetBookmarksFoldersResponse> GetBookmarksFoldersAsync(CancellationToken token);
    Task<GetItemsByBookmarkIdResponse> GetItemsByBookmarkIdAsync(long bookmarkId, CancellationToken token);
    Task<HttpResponseMessage> RemoveFolderAsync(long folderId, CancellationToken token);
    Task<HttpResponseMessage> RemoveItemFromFolder(long itemId, CancellationToken token, long? folderId = null);
}
