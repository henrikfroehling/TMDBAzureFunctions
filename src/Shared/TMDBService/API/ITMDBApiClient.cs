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
        Task<TMDBGenresResponse> GetShowGenresAsync(string apiKey, string languageCode);

        [Get("/genre/movie/list?api_key={apiKey}&language={languageCode}")]
        Task<TMDBGenresResponse> GetMovieGenresAsync(string apiKey, string languageCode);

        // popular

        [Get("/tv/popular?api_key={apiKey}&language={languageCode}&region={regionCode}&page={page}")]
        Task<TMDBListResponse<TMDBPopularShowResponse>> GetPopularShowsAsync(string apiKey, string languageCode, string regionCode, int page);

        [Get("/movie/popular?api_key={apiKey}&language={languageCode}&region={regionCode}&page={page}")]
        Task<TMDBListResponse<TMDBPopularMovieResponse>> GetPopularMoviesAsync(string apiKey, string languageCode, string regionCode, int page);

        // discoverable

        [Get("/discover/tv?api_key={apiKey}&language={languageCode}&watch_region={watchRegionCode}&with_genres={withGenres}&page={page}")]
        Task<TMDBListResponse<TMDBDiscoverableShowResponse>> GetDiscoverableShowsByGenresAsync(string apiKey, string withGenres, int page,
                                                                                               string languageCode, string watchRegionCode);

        [Get("/discover/movie?api_key={apiKey}&language={languageCode}&watch_region={watchRegionCode}&with_genres={withGenres}&page={page}")]
        Task<TMDBListResponse<TMDBDiscoverableMovieResponse>> GetDiscoverableMoviesByGenresAsync(string apiKey, string withGenres, int page,
                                                                                                 string languageCode, string watchRegionCode);

        [Get("/discover/tv?api_key={apiKey}&language={languageCode}&watch_region={watchRegionCode}&with_keywords={withKeywords}&page={page}")]
        Task<TMDBListResponse<TMDBDiscoverableShowResponse>> GetDiscoverableShowsByKeywordsAsync(string apiKey, string withKeywords, int page,
                                                                                                 string languageCode, string watchRegionCode);

        [Get("/discover/movie?api_key={apiKey}&language={languageCode}&watch_region={watchRegionCode}&with_keywords={withKeywords}&page={page}")]
        Task<TMDBListResponse<TMDBDiscoverableMovieResponse>> GetDiscoverableMoviesByKeywordsAsync(string apiKey, string withKeywords, int page,
                                                                                                   string languageCode, string watchRegionCode);
    }
}
