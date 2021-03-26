using CompressionService;
using Microsoft.Extensions.Logging;
using Models.TMDB;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using TMDBService;

namespace TMDBDataCollector.Utils
{
    public class DataCollector
    {
        private const int NUMBER_OF_PAGES = 1;

        public static async Task<TMDBSnapshot> CollectDataAsync(ITMDBService tmdbService, ILogger logger, string languageCode, string regionCode)
        {
            logger.LogInformation($"DataCollector collecting data for language \"{languageCode}\" started at: {DateTime.Now}");

            var tmdbSnapshot = new TMDBSnapshot
            {
                LanguageCode = languageCode,
                RegionCode = regionCode
            };

            tmdbSnapshot.Configuration = tmdbService.Configuration;
            tmdbSnapshot.ShowGenres = (await tmdbService.GetShowGenresAsync(languageCode)).Values.ToList();
            tmdbSnapshot.MovieGenres = (await tmdbService.GetMovieGenresAsync(languageCode)).Values.ToList();
            tmdbSnapshot.PopularShowsAndMovies = await tmdbService.GetPopularShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.ComedyShowsAndMovies = await tmdbService.GetComedyShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.DramaShowsAndMovies = await tmdbService.GetDramaShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.ActionAdventureShowsAndMovies = await tmdbService.GetActionAndAdventureShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.AnimationShowsAndMovies = await tmdbService.GetAnimationShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.ScifiShowsAndMovies = await tmdbService.GetScifiShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.CrimeShowsAndMovies = await tmdbService.GetCrimeShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.MysteryShowsAndMovies = await tmdbService.GetMysteryShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.ThrillerShowsAndMovies = await tmdbService.GetThrillerShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.HorrorShowsAndMovies = await tmdbService.GetHorrorShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.FamilyShowsAndMovies = await tmdbService.GetFamilyShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.KidsShowsAndMovies = await tmdbService.GetKidsShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.WesternShowsAndMovies = await tmdbService.GetWesternShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.FantasyMovies = await tmdbService.GetFantasyMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.HistoryShowsAndMovies = await tmdbService.GetHistoryShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.RomanceShowsAndMovies = await tmdbService.GetHistoryShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.WarShowsAndMovies = await tmdbService.GetWarShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.DocumentaryShowsAndMovies = await tmdbService.GetDocumentaryShowsAndMovies(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.SitcomShows = await tmdbService.GetSitcomShowsAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.AnthologyShows = await tmdbService.GetAnthologyShowsAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.AnimeShowsAndMovies = await tmdbService.GetAnimeShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.TeenDramaShowsAndMovies = await tmdbService.GetTeenDramaShowsAndMoviesAsync(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.HistoricalDramaShowsAndMovies = await tmdbService.GetHistoricalDramaShowsAndMovies(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.WorkplaceComedyShowsAndMovies = await tmdbService.GetWorkplaceComedyShowsAndMovies(languageCode, regionCode, NUMBER_OF_PAGES);
            tmdbSnapshot.MedicalDramaShowsAndMovies = await tmdbService.GetMedicalDramaShowsAndMovies(languageCode, regionCode, NUMBER_OF_PAGES);

            CollectionFilter.FilterCollections(tmdbSnapshot, logger);
            CreateRandomizedJSONCollection(tmdbSnapshot, logger);

            logger.LogInformation($"DataCollector collecting data for language \"{languageCode}\" finished at: {DateTime.Now}");
            return tmdbSnapshot;
        }

        private static void CreateRandomizedJSONCollection(TMDBSnapshot tmdbSnapshot, ILogger logger)
        {
            logger.LogInformation($"DataCollector creating json collection started at: {DateTime.Now}");
            RandomizedJSONSnapshot jsonSnapshot = CreateRandomizedCollection(tmdbSnapshot);
            string json = JsonConvert.SerializeObject(jsonSnapshot);
            var compressionService = new CompressionServiceImpl();
            string compressedJsonData = compressionService.CompressJSONAsBase64(json);
            tmdbSnapshot.CompressedBase64JSONData = compressedJsonData;
            logger.LogInformation($"DataCollector creating json collection finished at: {DateTime.Now}");
        }

        private static RandomizedJSONSnapshot CreateRandomizedCollection(TMDBSnapshot tmdbSnapshot)
        {
            var jsonSnapshot = new RandomizedJSONSnapshot
            {
                Configuration = tmdbSnapshot.Configuration,
                ShowGenres = tmdbSnapshot.ShowGenres,
                MovieGenres = tmdbSnapshot.MovieGenres,
                ActionAdventureShowsAndMovies = tmdbSnapshot.ActionAdventureShowsAndMovies,
                AnimationShowsAndMovies = tmdbSnapshot.AnimationShowsAndMovies,
                AnimeShowsAndMovies = tmdbSnapshot.AnimeShowsAndMovies,
                AnthologyShows = tmdbSnapshot.AnthologyShows,
                ComedyShowsAndMovies = tmdbSnapshot.ComedyShowsAndMovies,
                CrimeShowsAndMovies = tmdbSnapshot.CrimeShowsAndMovies,
                DocumentaryShowsAndMovies = tmdbSnapshot.DocumentaryShowsAndMovies,
                DramaShowsAndMovies = tmdbSnapshot.DramaShowsAndMovies,
                FamilyShowsAndMovies = tmdbSnapshot.FamilyShowsAndMovies,
                FantasyMovies = tmdbSnapshot.FantasyMovies,
                HistoricalDramaShowsAndMovies = tmdbSnapshot.HistoricalDramaShowsAndMovies,
                HistoryShowsAndMovies = tmdbSnapshot.HistoryShowsAndMovies,
                HorrorShowsAndMovies = tmdbSnapshot.HorrorShowsAndMovies,
                KidsShowsAndMovies = tmdbSnapshot.KidsShowsAndMovies,
                MedicalDramaShowsAndMovies = tmdbSnapshot.MedicalDramaShowsAndMovies,
                MysteryShowsAndMovies = tmdbSnapshot.MysteryShowsAndMovies,
                RomanceShowsAndMovies = tmdbSnapshot.RomanceShowsAndMovies,
                ScifiShowsAndMovies = tmdbSnapshot.ScifiShowsAndMovies,
                SitcomShows = tmdbSnapshot.SitcomShows,
                TeenDramaShowsAndMovies = tmdbSnapshot.TeenDramaShowsAndMovies,
                ThrillerShowsAndMovies = tmdbSnapshot.ThrillerShowsAndMovies,
                PopularShowsAndMovies = tmdbSnapshot.PopularShowsAndMovies,
                WarShowsAndMovies = tmdbSnapshot.WarShowsAndMovies,
                WesternShowsAndMovies = tmdbSnapshot.WesternShowsAndMovies,
                WorkplaceComedyShowsAndMovies = tmdbSnapshot.WorkplaceComedyShowsAndMovies
            };

            jsonSnapshot.ActionAdventureShowsAndMovies.Shuffle();
            jsonSnapshot.AnimationShowsAndMovies.Shuffle();
            jsonSnapshot.AnimeShowsAndMovies.Shuffle();
            jsonSnapshot.AnthologyShows.Shuffle();
            jsonSnapshot.ComedyShowsAndMovies.Shuffle();
            jsonSnapshot.CrimeShowsAndMovies.Shuffle();
            jsonSnapshot.DocumentaryShowsAndMovies.Shuffle();
            jsonSnapshot.DramaShowsAndMovies.Shuffle();
            jsonSnapshot.FamilyShowsAndMovies.Shuffle();
            jsonSnapshot.FantasyMovies.Shuffle();
            jsonSnapshot.HistoricalDramaShowsAndMovies.Shuffle();
            jsonSnapshot.HistoryShowsAndMovies.Shuffle();
            jsonSnapshot.HorrorShowsAndMovies.Shuffle();
            jsonSnapshot.KidsShowsAndMovies.Shuffle();
            jsonSnapshot.MedicalDramaShowsAndMovies.Shuffle();
            jsonSnapshot.MysteryShowsAndMovies.Shuffle();
            jsonSnapshot.RomanceShowsAndMovies.Shuffle();
            jsonSnapshot.ScifiShowsAndMovies.Shuffle();
            jsonSnapshot.SitcomShows.Shuffle();
            jsonSnapshot.TeenDramaShowsAndMovies.Shuffle();
            jsonSnapshot.ThrillerShowsAndMovies.Shuffle();
            jsonSnapshot.PopularShowsAndMovies.Shuffle();
            jsonSnapshot.WarShowsAndMovies.Shuffle();
            jsonSnapshot.WesternShowsAndMovies.Shuffle();
            jsonSnapshot.WorkplaceComedyShowsAndMovies.Shuffle();

            return jsonSnapshot;
        }
    }
}
