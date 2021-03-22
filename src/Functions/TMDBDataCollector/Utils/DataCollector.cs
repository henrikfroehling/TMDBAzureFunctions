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

        public static async Task<TMDBCollection> CollectDataAsync(ITMDBService tmdbService, ILogger logger, string languageCode, string regionCode)
        {
            logger.LogInformation($"DataCollector collecting data for language \"{languageCode}\" started at: {DateTime.Now}");

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

            CollectionFilter.FilterCollections(tmdbCollection, logger);
            CreateRandomizedJSONCollection(tmdbCollection, logger);

            logger.LogInformation($"DataCollector collecting data for language \"{languageCode}\" finished at: {DateTime.Now}");
            return tmdbCollection;
        }

        private static void CreateRandomizedJSONCollection(TMDBCollection collection, ILogger logger)
        {
            logger.LogInformation($"DataCollector creating json collection started at: {DateTime.Now}");
            RandomizedJSONCollection jsonCollection = CreateRandomizedCollection(collection);
            string json = JsonConvert.SerializeObject(jsonCollection);
            var compressionService = new CompressionServiceImpl();
            string compressedJsonData = compressionService.CompressJSONAsBase64(json);
            collection.CompressedBase64JSONData = compressedJsonData;
            logger.LogInformation($"DataCollector creating json collection finished at: {DateTime.Now}");
        }

        private static RandomizedJSONCollection CreateRandomizedCollection(TMDBCollection collection)
        {
            var randomizedCollection = new RandomizedJSONCollection
            {
                Configuration = collection.Configuration,
                ShowGenres = collection.ShowGenres,
                MovieGenres = collection.MovieGenres,
                ActionAdventureShowsAndMovies = collection.ActionAdventureShowsAndMovies,
                AnimationShowsAndMovies = collection.AnimationShowsAndMovies,
                AnimeShowsAndMovies = collection.AnimeShowsAndMovies,
                AnthologyShows = collection.AnthologyShows,
                ComedyShowsAndMovies = collection.ComedyShowsAndMovies,
                CrimeShowsAndMovies = collection.CrimeShowsAndMovies,
                DocumentaryShowsAndMovies = collection.DocumentaryShowsAndMovies,
                DramaShowsAndMovies = collection.DramaShowsAndMovies,
                FamilyShowsAndMovies = collection.FamilyShowsAndMovies,
                FantasyMovies = collection.FantasyMovies,
                HistoricalDramaShowsAndMovies = collection.HistoricalDramaShowsAndMovies,
                HistoryShowsAndMovies = collection.HistoryShowsAndMovies,
                HorrorShowsAndMovies = collection.HorrorShowsAndMovies,
                KidsShowsAndMovies = collection.KidsShowsAndMovies,
                MedicalDramaShowsAndMovies = collection.MedicalDramaShowsAndMovies,
                MysteryShowsAndMovies = collection.MysteryShowsAndMovies,
                RomanceShowsAndMovies = collection.RomanceShowsAndMovies,
                ScifiShowsAndMovies = collection.ScifiShowsAndMovies,
                SitcomShows = collection.SitcomShows,
                TeenDramaShowsAndMovies = collection.TeenDramaShowsAndMovies,
                ThrillerShowsAndMovies = collection.ThrillerShowsAndMovies,
                TrendingShowsAndMovies = collection.TrendingShowsAndMovies,
                WarShowsAndMovies = collection.WarShowsAndMovies,
                WesternShowsAndMovies = collection.WesternShowsAndMovies,
                WorkplaceComedyShowsAndMovies = collection.WorkplaceComedyShowsAndMovies
            };

            randomizedCollection.ActionAdventureShowsAndMovies.Shuffle();
            randomizedCollection.AnimationShowsAndMovies.Shuffle();
            randomizedCollection.AnimeShowsAndMovies.Shuffle();
            randomizedCollection.AnthologyShows.Shuffle();
            randomizedCollection.ComedyShowsAndMovies.Shuffle();
            randomizedCollection.CrimeShowsAndMovies.Shuffle();
            randomizedCollection.DocumentaryShowsAndMovies.Shuffle();
            randomizedCollection.DramaShowsAndMovies.Shuffle();
            randomizedCollection.FamilyShowsAndMovies.Shuffle();
            randomizedCollection.FantasyMovies.Shuffle();
            randomizedCollection.HistoricalDramaShowsAndMovies.Shuffle();
            randomizedCollection.HistoryShowsAndMovies.Shuffle();
            randomizedCollection.HorrorShowsAndMovies.Shuffle();
            randomizedCollection.KidsShowsAndMovies.Shuffle();
            randomizedCollection.MedicalDramaShowsAndMovies.Shuffle();
            randomizedCollection.MysteryShowsAndMovies.Shuffle();
            randomizedCollection.RomanceShowsAndMovies.Shuffle();
            randomizedCollection.ScifiShowsAndMovies.Shuffle();
            randomizedCollection.SitcomShows.Shuffle();
            randomizedCollection.TeenDramaShowsAndMovies.Shuffle();
            randomizedCollection.ThrillerShowsAndMovies.Shuffle();
            randomizedCollection.TrendingShowsAndMovies.Shuffle();
            randomizedCollection.WarShowsAndMovies.Shuffle();
            randomizedCollection.WesternShowsAndMovies.Shuffle();
            randomizedCollection.WorkplaceComedyShowsAndMovies.Shuffle();

            return randomizedCollection;
        }
    }
}
