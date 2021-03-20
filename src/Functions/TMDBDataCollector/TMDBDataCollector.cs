using DatabaseService;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Models.TMDB;
using System;
using System.Linq;
using System.Threading.Tasks;
using TMDBDataCollector.Utils;
using TMDBService;

namespace TMDBDataCollector
{
    public static class TMDBDataCollector
    {
        private static ITMDBService _tmdbService;
        private static TMDBCollection _tmdbCollection;
        private static string _tmdbApiKey;

        [FunctionName("TMDBDataCollector")]
        public static async Task Run([TimerTrigger("0 0 * * * *" /* runs every hour */
#if DEBUG
            , RunOnStartup = true
#endif
            )]TimerInfo myTimer, ILogger log)
        {
            _tmdbApiKey = Environment.GetEnvironmentVariable("tmdb_api_key");
            log.LogInformation($"TMDBDataCollector function started at: {DateTime.Now}");

            _tmdbService = new TMDBServiceImpl(_tmdbApiKey, log);
            await _tmdbService.InitializeAsync();
            _tmdbCollection = await DataCollector.CollectDataAsync(_tmdbService);
            _tmdbCollection.Configuration = _tmdbService.Configuration;
            _tmdbCollection.ShowGenres = _tmdbService.ShowGenres.Values.ToList();
            _tmdbCollection.MovieGenres = _tmdbService.MovieGenres.Values.ToList();

            log.LogInformation($"TMDBDataCollector filtering collections started at: {DateTime.Now}");
            CollectionFilter.FilterCollections(_tmdbCollection);
            log.LogInformation($"TMDBDataCollector filtering collections finished at: {DateTime.Now}");

            WriteIntoDatabase(_tmdbCollection, log);

            log.LogInformation($"TMDBDataCollector function finished at: {DateTime.Now}");
        }

        private static void WriteIntoDatabase(TMDBCollection collection, ILogger logger)
        {
            string databaseConnection = Environment.GetEnvironmentVariable("database_connection");
            logger.LogInformation($"TMDBDataCollector writing data into database started at: {DateTime.Now}");
            
            using IDatabaseService databaseService = new DatabaseServiceImpl(databaseConnection);
            databaseService.SaveCollectedDataToDatabase(collection);
            
            logger.LogInformation($"TMDBDataCollector writing data into database finished at: {DateTime.Now}");
        }
    }
}
