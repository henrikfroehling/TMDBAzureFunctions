using Models.TMDB;
using System.Linq;
using System.Threading.Tasks;
using TMDBService;

namespace TMDBDataCollector.Utils
{
    public class DataCollector
    {
        private const int NUMBER_OF_PAGES = 2;

        public static async Task<TMDBCollection> CollectDataAsync(ITMDBService tmdbService, string languageCode, string regionCode)
        {
            var tmdbCollection = new TMDBCollection
            {
                LanguageCode = languageCode,
                RegionCode = regionCode
            };

            tmdbCollection.Configuration = tmdbService.Configuration;
            tmdbCollection.ShowGenres = (await tmdbService.GetShowGenresAsync(languageCode)).Values.ToList();
            tmdbCollection.MovieGenres = (await tmdbService.GetMovieGenresAsync(languageCode)).Values.ToList();
            tmdbCollection.TrendingShowsAndMovies = await tmdbService.GetTrendingShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.ComedyShowsAndMovies = await tmdbService.GetComedyShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.DramaShowsAndMovies = await tmdbService.GetDramaShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.ActionAdventureShowsAndMovies = await tmdbService.GetActionAndAdventureShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.AnimationShowsAndMovies = await tmdbService.GetAnimationShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.ScifiShowsAndMovies = await tmdbService.GetScifiShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.CrimeShowsAndMovies = await tmdbService.GetCrimeShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.MysteryShowsAndMovies = await tmdbService.GetMysteryShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.ThrillerShowsAndMovies = await tmdbService.GetThrillerShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.HorrorShowsAndMovies = await tmdbService.GetHorrorShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.FamilyShowsAndMovies = await tmdbService.GetFamilyShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.KidsShowsAndMovies = await tmdbService.GetKidsShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.WesternShowsAndMovies = await tmdbService.GetWesternShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.FantasyMovies = await tmdbService.GetFantasyMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.HistoryShowsAndMovies = await tmdbService.GetHistoryShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.RomanceShowsAndMovies = await tmdbService.GetHistoryShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.WarShowsAndMovies = await tmdbService.GetWarShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.DocumentaryShowsAndMovies = await tmdbService.GetDocumentaryShowsAndMovies(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.SitcomShows = await tmdbService.GetSitcomShowsAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.AnthologyShows = await tmdbService.GetAnthologyShowsAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.AnimeShowsAndMovies = await tmdbService.GetAnimeShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.TeenDramaShowsAndMovies = await tmdbService.GetTeenDramaShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.HistoricalDramaShowsAndMovies = await tmdbService.GetHistoricalDramaShowsAndMovies(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.WorkplaceComedyShowsAndMovies = await tmdbService.GetWorkplaceComedyShowsAndMovies(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbCollection.MedicalDramaShowsAndMovies = await tmdbService.GetMedicalDramaShowsAndMovies(languageCode, regionCode, NUMBER_OF_PAGES);

            return tmdbCollection;
        }
    }
}
