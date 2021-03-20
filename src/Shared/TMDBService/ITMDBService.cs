using Models.TMDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TMDBService
{
    public interface ITMDBService
    {
        Configuration Configuration { get; }

        Task InitializeAsync();

        Task<Dictionary<int, Genre>> GetShowGenresAsync(string languageCode);

        Task<Dictionary<int, Genre>> GetMovieGenresAsync(string languageCode);

        Task<List<ListItem>> GetTrendingShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetComedyShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetActionAndAdventureShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetDramaShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetAnimationShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetScifiShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetCrimeShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetMysteryShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetThrillerShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetHorrorShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetFamilyShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetKidsShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetFantasyMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetWesternShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetHistoryShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetRomanceShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetWarShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetDocumentaryShowsAndMovies(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetSitcomShowsAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetAnthologyShowsAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetAnimeShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetTeenDramaShowsAndMoviesAsync(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetHistoricalDramaShowsAndMovies(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetWorkplaceComedyShowsAndMovies(string languageCode, string regionCode, int pageCount = 1);

        Task<List<ListItem>> GetMedicalDramaShowsAndMovies(string languageCode, string regionCode, int pageCount = 1);

        void Clear();
    }
}
