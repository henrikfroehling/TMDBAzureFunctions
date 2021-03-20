using Models.TMDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TMDBService
{
    public interface ITMDBService
    {
        Configuration Configuration { get; }

        Dictionary<int, Genre> ShowGenres { get; }

        Dictionary<int, Genre> MovieGenres { get; }

        Task InitializeAsync();

        Task<List<ListItem>> GetTrendingShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetComedyShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetActionAndAdventureShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetDramaShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetAnimationShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetScifiShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetCrimeShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetMysteryShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetThrillerShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetHorrorShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetFamilyShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetKidsShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetFantasyMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetWesternShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetHistoryShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetRomanceShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetWarShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetDocumentaryShowsAndMovies(int pageCount = 1);

        Task<List<ListItem>> GetSitcomShowsAsync(int pageCount = 1);

        Task<List<ListItem>> GetAnthologyShowsAsync(int pageCount = 1);

        Task<List<ListItem>> GetAnimeShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetTeenDramaShowsAndMoviesAsync(int pageCount = 1);

        Task<List<ListItem>> GetHistoricalDramaShowsAndMovies(int pageCount = 1);

        Task<List<ListItem>> GetWorkplaceComedyShowsAndMovies(int pageCount = 1);

        Task<List<ListItem>> GetMedicalDramaShowsAndMovies(int pageCount = 1);
    }
}
