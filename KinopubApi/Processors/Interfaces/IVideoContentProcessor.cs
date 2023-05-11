using KinopubApi.Enums;
using KinopubApi.Responses;

namespace KinopubApi.Processors.Interfaces;

public interface IVideoContentProcessor
{
    Task<GetCommentsResponse> GetCommentsAsync(long itemId, CancellationToken token);
    Task<GetContentGenresResponse> GetContentGenresAsync(CancellationToken token, GenreType? type = null);
    Task<GetContentTypesResponse> GetContentTypesAsync(CancellationToken token);
    Task<GetItemsResponse> GetFreshAsync(GenreType type, CancellationToken token, int numPage = 0, int perPage = 25);
    Task<GetItemsResponse> GetHotAsync(GenreType type, CancellationToken token, int numPage = 0, int perPage = 25);
    Task<GetItemResponse> GetItemAsync(long itemId, CancellationToken token, bool? noLinks = null);
    Task<GetItemsResponse> GetItemsAsync(CancellationToken token, string type = null, string title = null, long? genreId = null, long? country = null, int? year = null, int? isFinished = null, string actors = null, string director = null, string letter = null, SortBy sort = SortBy.Rating, bool isAsc = true, string qualityIds = null);
    Task<GetItemsResponse> GetPopularAsync(GenreType type, CancellationToken token, int numPage = 0, int perPage = 25);
    Task<GetItemsResponse> GetSimilarAsync(long itemId, CancellationToken token);
    Task<GetSubtitlesAndVideosResponse> GetSubtitlesAndVideosAsync(long mediaId, CancellationToken token);
    Task<GetTrailerResponse> GetTrailerAsync(long itemId, CancellationToken token);
    Task<UrlItem> GetVideoFileUrlAsync(string filePath, StreamType type, CancellationToken token);
    Task<GetСountriesResponse> GetСountriesAsync(CancellationToken token);
    Task<GetItemsResponse> SearchAsync(string q, CancellationToken token, int? countPerPage = null, Field? field = null, GenreType? type = null);
    Task<VoteForVideoResponse> VoteForVideoAsync(long itemId, bool isLike, CancellationToken token);
}
