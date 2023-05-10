using KinopubApi.Enums;
using KinopubApi.Processors.Impls;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Interfaces;

public interface IVideoContentProcessor
{
    Task<GetCommentsResponse> GetCommentsAsync(long itemId);
    Task<GetContentGenresResponse> GetContentGenresAsync(GenreType? type = null);
    Task<GetContentTypesResponse> GetContentTypesAsync();
    Task<GetItemsResponse> GetFreshAsync(GenreType type, int numPage = 0, int perPage = 25);
    Task<GetItemsResponse> GetHotAsync(GenreType type, int numPage = 0, int perPage = 25);
    Task<GetItemResponse> GetItemAsync(long itemId, bool? noLinks = null);
    Task<GetItemsResponse> GetItemsAsync(string type = null, string title = null, long? genreId = null, long? country = null, int? year = null, int? isFinished = null, string actors = null, string director = null, string letter = null, SortBy sort = SortBy.Rating, bool isAsc = true, string qualityIds = null);
    Task<GetItemsResponse> GetPopularAsync(GenreType type, int numPage = 0, int perPage = 25);
    Task<GetItemsResponse> GetSimilarAsync(long itemId);
    Task<GetSubtitlesAndVideosResponse> GetSubtitlesAndVideosAsync(long mediaId);
    Task<GetTrailerResponse> GetTrailerAsync(long itemId);
    Task<UrlItem> GetVideoFileUrlAsync(string filePath, StreamType type);
    Task<GetСountriesResponse> GetСountriesAsync();
    Task<GetItemsResponse> SearchAsync(string q, int? countPerPage = null, Field? field = null, GenreType? type = null);
    Task<VoteForVideoResponse> VoteForVideoAsync(long itemId, bool isLike);
}
