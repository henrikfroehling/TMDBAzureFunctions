using Models.TMDBApi;
using Refit;
using System.Threading.Tasks;

namespace TMDBService.API
{
    public interface ITMDBApiClient
    {
        [Get("/configuration?api_key={apiKey}")]
        Task<TMDBConfigurationResponse> GetConfigurationAsync(string apiKey);

        // genres

        [Get("/genre/tv/list?api_key={apiKey}&language={languageCode}")]
        Task<TMDBGenresResponse> GetShowGenresAsync(string apiKey, string languageCode = "de-DE");

        [Get("/genre/movie/list?api_key={apiKey}&language={languageCode}")]
        Task<TMDBGenresResponse> GetMovieGenresAsync(string apiKey, string languageCode = "de-DE");

        // trending

        [Get("/trending/tv/day?api_key={apiKey}&language={languageCode}&page={page}")]
        Task<TMDBListResponse<TMDBTrendingShowResponse>> GetTrendingShowsAsync(string apiKey, string languageCode = "de-DE", int page = 1);

        [Get("/trending/movie/day?api_key={apiKey}&language={languageCode}&page={page}")]
        Task<TMDBListResponse<TMDBTrendingMovieResponse>> GetTrendingMoviesAsync(string apiKey, string languageCode = "de-DE", int page = 1);

        // discoverable

        [Get("/discover/tv?api_key={apiKey}&language={languageCode}&watch_region={watchRegionCode}&with_genres={withGenres}&page={page}")]
        Task<TMDBListResponse<TMDBDiscoverableShowResponse>> GetDiscoverableShowsByGenresAsync(string apiKey, string withGenres, int page = 1,
                                                                                               string languageCode = "de-DE", string watchRegionCode = "DE");

        [Get("/discover/movie?api_key={apiKey}&language={languageCode}&watch_region={watchRegionCode}&with_genres={withGenres}&page={page}")]
        Task<TMDBListResponse<TMDBDiscoverableMovieResponse>> GetDiscoverableMoviesByGenresAsync(string apiKey, string withGenres, int page = 1,
                                                                                                 string languageCode = "de-DE", string watchRegionCode = "DE");

        [Get("/discover/tv?api_key={apiKey}&language={languageCode}&watch_region={watchRegionCode}&with_keywords={withKeywords}&page={page}")]
        Task<TMDBListResponse<TMDBDiscoverableShowResponse>> GetDiscoverableShowsByKeywordsAsync(string apiKey, string withKeywords, int page = 1,
                                                                                                 string languageCode = "de-DE", string watchRegionCode = "DE");

        [Get("/discover/movie?api_key={apiKey}&language={languageCode}&watch_region={watchRegionCode}&with_keywords={withKeywords}&page={page}")]
        Task<TMDBListResponse<TMDBDiscoverableMovieResponse>> GetDiscoverableMoviesByKeywordsAsync(string apiKey, string withKeywords, int page = 1,
                                                                                                   string languageCode = "de-DE", string watchRegionCode = "DE");
    }
}
