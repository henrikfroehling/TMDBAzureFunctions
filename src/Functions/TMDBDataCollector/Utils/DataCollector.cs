using Models.TMDB;
using System.Threading.Tasks;
using TMDBService;

namespace TMDBDataCollector.Utils
{
    public class DataCollector
    {
        private const int NUMBER_OF_PAGES = 2;

        public static async Task<TMDBCollection> CollectDataAsync(ITMDBService tmdbService)
        {
            var tmdbCollection = new TMDBCollection();

            tmdbCollection.TrendingShowsAndMovies = await tmdbService.GetTrendingShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.ComedyShowsAndMovies = await tmdbService.GetComedyShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.DramaShowsAndMovies = await tmdbService.GetDramaShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.ActionAdventureShowsAndMovies = await tmdbService.GetActionAndAdventureShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.AnimationShowsAndMovies = await tmdbService.GetAnimationShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.ScifiShowsAndMovies = await tmdbService.GetScifiShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.CrimeShowsAndMovies = await tmdbService.GetCrimeShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.MysteryShowsAndMovies = await tmdbService.GetMysteryShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.ThrillerShowsAndMovies = await tmdbService.GetThrillerShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.HorrorShowsAndMovies = await tmdbService.GetHorrorShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.FamilyShowsAndMovies = await tmdbService.GetFamilyShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.KidsShowsAndMovies = await tmdbService.GetKidsShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.WesternShowsAndMovies = await tmdbService.GetWesternShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.FantasyMovies = await tmdbService.GetFantasyMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.HistoryShowsAndMovies = await tmdbService.GetHistoryShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.RomanceShowsAndMovies = await tmdbService.GetHistoryShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.WarShowsAndMovies = await tmdbService.GetWarShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.DocumentaryShowsAndMovies = await tmdbService.GetDocumentaryShowsAndMovies(NUMBER_OF_PAGES);
            tmdbCollection.SitcomShows = await tmdbService.GetSitcomShowsAsync(NUMBER_OF_PAGES);
            tmdbCollection.AnthologyShows = await tmdbService.GetAnthologyShowsAsync(NUMBER_OF_PAGES);
            tmdbCollection.AnimeShowsAndMovies = await tmdbService.GetAnimeShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.TeenDramaShowsAndMovies = await tmdbService.GetTeenDramaShowsAndMoviesAsync(NUMBER_OF_PAGES);
            tmdbCollection.HistoricalDramaShowsAndMovies = await tmdbService.GetHistoricalDramaShowsAndMovies(NUMBER_OF_PAGES);
            tmdbCollection.WorkplaceComedyShowsAndMovies = await tmdbService.GetWorkplaceComedyShowsAndMovies(NUMBER_OF_PAGES);
            tmdbCollection.MedicalDramaShowsAndMovies = await tmdbService.GetMedicalDramaShowsAndMovies(NUMBER_OF_PAGES);

            return tmdbCollection;
        }
    }
}
