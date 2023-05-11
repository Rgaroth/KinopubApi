using KinopubApi.Enums;
using KinopubApi.Processors.Interfaces;
using KinopubApi.Responses;
using System.Reflection;

namespace KinopubApi.Processors.Impls;

internal class VideoContentProcessor : BaseProcessor, IVideoContentProcessor
{
    public VideoContentProcessor(HttpClient httpClient, string clientId, string clientSecret) : base(httpClient, clientId, clientSecret)
    {
    }

    public async Task<GetContentTypesResponse> GetContentTypesAsync()
    {
        return await HttpClient.SendRequestAsync<GetContentTypesResponse>(HttpMethod.Get, "/v1/types");
    }

    public async Task<GetContentGenresResponse> GetContentGenresAsync(GenreType? type = null)
    {
        return await HttpClient.SendRequestAsync<GetContentGenresResponse>(HttpMethod.Get, $"/v1/genres",
            HttpRequestExtensions.CreateParameters(("type", type)));
    }

    public async Task<GetСountriesResponse> GetСountriesAsync()
    {
        return await HttpClient.SendRequestAsync<GetСountriesResponse>(HttpMethod.Get, "/v1/countries");
    }

    public async Task<GetItemsResponse> GetItemsAsync(
        string type = null,
        string title = null,
        long? genreId = null,
        long? country = null,
        int? year = null,
        int? isFinished = null,
        string actors = null,
        string director = null,
        string letter = null,
        SortBy sort = SortBy.Rating,
        bool isAsc = true,
        string qualityIds = null)
    {
        var parameters = new { type, title, genreId, country, year, isFinished, actors, director, letter, qualityIds };
        var dict = new Dictionary<string, string>();

        foreach (PropertyInfo pi in parameters.GetType().GetProperties())
        {
            var value = pi.GetValue(parameters, null);

            if (value != null)
            {
                dict.Add(pi.Name, value.ToString());
            }
        }

        string order = !isAsc ? "-" : "";
        dict.Add("sort", $"{sort}{order}");


        return await HttpClient.SendRequestAsync<GetItemsResponse>(HttpMethod.Get, $"/v1/items", dict);
    }

    public async Task<GetItemsResponse> SearchAsync(string q, int? countPerPage = null, Field? field = null, GenreType? type = null)
    {
        return await HttpClient.SendRequestAsync<GetItemsResponse>(HttpMethod.Get, $"/v1/items/search",
            HttpRequestExtensions.CreateParameters(
                ("q", q),
                ("perpage", countPerPage),
                ("field", field),
                ("type", type)));
    }

    public async Task<GetItemsResponse> GetSimilarAsync(long itemId)
    {
        return await HttpClient.SendRequestAsync<GetItemsResponse>(HttpMethod.Get, $"/v1/items/similar",
            HttpRequestExtensions.CreateParameters(("id", itemId)));
    }

    public async Task<GetItemResponse> GetItemAsync(long itemId, bool? noLinks = null)
    {
        return await HttpClient.SendRequestAsync<GetItemResponse>(HttpMethod.Get, $"/v1/items/{itemId}",
            HttpRequestExtensions.CreateParameters(("nolinks", "1")));
    }

    public async Task<GetSubtitlesAndVideosResponse> GetSubtitlesAndVideosAsync(long mediaId)
    {
        return await HttpClient.SendRequestAsync<GetSubtitlesAndVideosResponse>(HttpMethod.Get, $"/v1/items/media-links",
            HttpRequestExtensions.CreateParameters(("mid", mediaId)));
    }

    public async Task<UrlItem> GetVideoFileUrlAsync(string filePath, StreamType type)
    {
        return await HttpClient.SendRequestAsync<UrlItem>(HttpMethod.Get, $"/v1/items/media-video-link",
            HttpRequestExtensions.CreateParameters(
                ("file", filePath),
                ("type", type)));
    }

    public async Task<VoteForVideoResponse> VoteForVideoAsync(long itemId, bool isLike)
    {
        return await HttpClient.SendRequestAsync<VoteForVideoResponse>(HttpMethod.Get, $"/v1/items/vote",
            HttpRequestExtensions.CreateParameters(
                ("id", itemId),
                ("like", isLike ? "1" : "0")));
    }

    public async Task<GetCommentsResponse> GetCommentsAsync(long itemId)
    {
        return await HttpClient.SendRequestAsync<GetCommentsResponse>(HttpMethod.Get, $"/v1/items/comments",
           new Dictionary<string, string>
           {
               {"id", itemId.ToString()}
           });
    }

    public async Task<GetTrailerResponse> GetTrailerAsync(long itemId)
    {
        return await HttpClient.SendRequestAsync<GetTrailerResponse>(HttpMethod.Get, $"/v1/items/trailer",
            HttpRequestExtensions.CreateParameters(("id", itemId)));
    }

    public async Task<GetItemsResponse> GetFreshAsync(GenreType type, int numPage = 0, int perPage = 25)
    {
        return await HttpClient.SendRequestAsync<GetItemsResponse>(HttpMethod.Get, $"/v1/items/fresh",
            HttpRequestExtensions.CreateParameters(
                ("type", type),
                ("page", numPage),
                ("perpage", perPage)));
    }

    public async Task<GetItemsResponse> GetHotAsync(GenreType type, int numPage = 0, int perPage = 25)
    {
        return await HttpClient.SendRequestAsync<GetItemsResponse>(HttpMethod.Get, $"/v1/items/hot",
             HttpRequestExtensions.CreateParameters(
                ("type", type),
                ("page", numPage),
                ("perpage", perPage)));
    }

    public async Task<GetItemsResponse> GetPopularAsync(GenreType type, int numPage = 0, int perPage = 25)
    {
        return await HttpClient.SendRequestAsync<GetItemsResponse>(HttpMethod.Get, $"/v1/items/popular",
             HttpRequestExtensions.CreateParameters(
                ("type", type),
                ("page", numPage),
                ("perpage", perPage)));
    }
}
