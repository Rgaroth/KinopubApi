using KinopubApi.Responses;

namespace KinopubApi.Processors.Interfaces;

public interface IBookmarksProcessor
{
    Task<HttpResponseMessage> AddItemToFolder(long itemId, long folderId);
    Task<CreateFolderResponse> CreateFolderAsync(string folderName);
    Task<GetBookmarksFoldersResponse> GetBookmarksFoldersAsync();
    Task<GetItemsByBookmarkIdResponse> GetItemsByBookmarkIdAsync(long bookmarkId);
    Task<HttpResponseMessage> RemoveFolderAsync(long folderId);
    Task<HttpResponseMessage> RemoveItemFromFolder(long itemId, long? folderId = null);
}
