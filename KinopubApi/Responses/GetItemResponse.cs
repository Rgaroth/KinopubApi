using Newtonsoft.Json;
namespace KinopubApi.Responses;

public class GetItemResponse
{
    [JsonProperty("status")]
    public int? Status { get; set; }

    [JsonProperty("item")]
    public ContentItem Item { get; set; }

    public class Audio
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("index")]
        public int? Index { get; set; }

        [JsonProperty("codec")]
        public string Codec { get; set; }

        [JsonProperty("channels")]
        public int? Channels { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("type")]
        public Type Type { get; set; }

        [JsonProperty("author")]
        public object Author { get; set; }
    }

    public class Country
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class Duration
    {
        [JsonProperty("average")]
        public double? Average { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }

    public class FileItem
    {
        [JsonProperty("codec")]
        public string Codec { get; set; }

        [JsonProperty("w")]
        public int? W { get; set; }

        [JsonProperty("h")]
        public int? H { get; set; }

        [JsonProperty("quality")]
        public string Quality { get; set; }

        [JsonProperty("quality_id")]
        public int? QualityId { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("url")]
        public Url Url { get; set; }
    }

    public class Genre
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class ContentItem
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("subtype")]
        public string Subtype { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonProperty("cast")]
        public string Cast { get; set; }

        [JsonProperty("director")]
        public string Director { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("countries")]
        public List<Country> Countries { get; set; }

        [JsonProperty("voice")]
        public object Voice { get; set; }

        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("ac3")]
        public int? Ac3 { get; set; }

        [JsonProperty("langs")]
        public int? Langs { get; set; }

        [JsonProperty("quality")]
        public int? Quality { get; set; }

        [JsonProperty("plot")]
        public string Plot { get; set; }

        [JsonProperty("tracklist")]
        public List<object> Tracklist { get; set; }

        [JsonProperty("imdb")]
        public int? Imdb { get; set; }

        [JsonProperty("imdb_rating")]
        public double? ImdbRating { get; set; }

        [JsonProperty("imdb_votes")]
        public int? ImdbVotes { get; set; }

        [JsonProperty("kinopoisk")]
        public int? Kinopoisk { get; set; }

        [JsonProperty("kinopoisk_rating")]
        public double? KinopoiskRating { get; set; }

        [JsonProperty("kinopoisk_votes")]
        public int? KinopoiskVotes { get; set; }

        [JsonProperty("rating")]
        public int? Rating { get; set; }

        [JsonProperty("rating_votes")]
        public int? RatingVotes { get; set; }

        [JsonProperty("rating_percentage")]
        public int? RatingPercentage { get; set; }

        [JsonProperty("views")]
        public int? Views { get; set; }

        [JsonProperty("comments")]
        public int? Comments { get; set; }

        [JsonProperty("posters")]
        public Posters Posters { get; set; }

        [JsonProperty("trailer")]
        public Trailer Trailer { get; set; }

        [JsonProperty("finished")]
        public bool Finished { get; set; }

        [JsonProperty("advert")]
        public bool Advert { get; set; }

        [JsonProperty("poor_quality")]
        public bool PoorQuality { get; set; }

        [JsonProperty("created_at")]
        public int? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public int? UpdatedAt { get; set; }

        [JsonProperty("bookmarks")]
        public List<object> Bookmarks { get; set; }

        [JsonProperty("videos")]
        public List<Video> Videos { get; set; }

        [JsonProperty("seasons")]
        public List<Season> Seasons { get; set; }
    }

    public class Season
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("number")]
        public int? Number { get; set; }

        [JsonProperty("watching")]
        public Watching Watching { get; set; }

        [JsonProperty("episodes")]
        public List<Episode> Episodes { get; set; }
    }

    public class Episode
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("number")]
        public int? Number { get; set; }

        [JsonProperty("snumber")]
        public int? Snumber { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("tracks")]
        public int? Tracks { get; set; }

        [JsonProperty("duration")]
        public int? Duration { get; set; }

        [JsonProperty("ac3")]
        public int? Ac3 { get; set; }

        [JsonProperty("audios")]
        public List<Audio> Audios { get; set; }

        [JsonProperty("subtitles")]
        public List<Subtitle> Subtitles { get; set; }

        [JsonProperty("files")]
        public List<File> Files { get; set; }

        [JsonProperty("watched")]
        public int? Watched { get; set; }

        [JsonProperty("watching")]
        public Watching Watching { get; set; }
    }

    public class File
    {
        [JsonProperty("codec")]
        public string Codec { get; set; }

        [JsonProperty("w")]
        public int? W { get; set; }

        [JsonProperty("h")]
        public int? H { get; set; }

        [JsonProperty("quality")]
        public string Quality { get; set; }

        [JsonProperty("quality_id")]
        public int? QualityId { get; set; }

        [JsonProperty("file")]
        public string FileName { get; set; }

        [JsonProperty("url")]
        public Url Url { get; set; }
    }

    public class Posters
    {
        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("big")]
        public string Big { get; set; }

        [JsonProperty("wide")]
        public string Wide { get; set; }
    }

    public class Subtitle
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("shift")]
        public int? Shift { get; set; }

        [JsonProperty("embed")]
        public bool Embed { get; set; }

        [JsonProperty("forced")]
        public bool Forced { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Trailer
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Type
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("short_title")]
        public string ShortTitle { get; set; }
    }

    public class Url
    {
        [JsonProperty("http")]
        public string Http { get; set; }

        [JsonProperty("hls")]
        public string Hls { get; set; }

        [JsonProperty("hls4")]
        public string Hls4 { get; set; }

        [JsonProperty("hls2")]
        public string Hls2 { get; set; }
    }

    public class Video
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("number")]
        public int? Number { get; set; }

        [JsonProperty("snumber")]
        public int? Snumber { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("tracks")]
        public int? Tracks { get; set; }

        [JsonProperty("duration")]
        public int? Duration { get; set; }

        [JsonProperty("ac3")]
        public int? Ac3 { get; set; }

        [JsonProperty("audios")]
        public List<Audio> Audios { get; set; }

        [JsonProperty("subtitles")]
        public List<Subtitle> Subtitles { get; set; }

        [JsonProperty("files")]
        public List<FileItem> Files { get; set; }

        [JsonProperty("watched")]
        public int? Watched { get; set; }

        [JsonProperty("watching")]
        public Watching Watching { get; set; }
    }

    public class Watching
    {
        [JsonProperty("status")]
        public int? Status { get; set; }

        [JsonProperty("time")]
        public int? Time { get; set; }
    }
}
