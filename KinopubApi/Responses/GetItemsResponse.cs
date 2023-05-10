using Newtonsoft.Json;

namespace KinopubApi.Responses;

public class GetItemsResponse
{
    [JsonProperty("status")]
    public int? Status { get; set; }

    [JsonProperty("items")]
    public List<Item> Items { get; set; }

    [JsonProperty("pagination")]
    public Pagination Pag { get; set; }

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
        public double Average { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }

    public class Genre
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class Item
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
        public string Voice { get; set; }

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
        public List<Tracklist> Tracklist { get; set; }

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

        [JsonProperty("subscribed")]
        public bool Subscribed { get; set; }

        [JsonProperty("in_watchlist")]
        public bool InWatchlist { get; set; }
    }

    public class Pagination
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("current")]
        public int? Current { get; set; }

        [JsonProperty("perpage")]
        public int? Perpage { get; set; }

        [JsonProperty("total_items")]
        public int? TotalItems { get; set; }
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

    public class Tracklist
    {
        [JsonProperty("artists")]
        public string Artists { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Trailer
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }
    }
}
