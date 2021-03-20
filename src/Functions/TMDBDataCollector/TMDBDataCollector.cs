using DatabaseService;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Models.Database;
using Models.TMDB;
using System;
using System.Collections.Generic;
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
        private static string _databaseConnection;

        [FunctionName("TMDBDataCollector")]
        public static async Task Run([TimerTrigger("0 0 * * * *" /* runs every hour */
#if DEBUG
            , RunOnStartup = true
#endif
            )]TimerInfo myTimer, ILogger log)
        {
            _tmdbApiKey = Environment.GetEnvironmentVariable("tmdb_api_key");
            _databaseConnection = Environment.GetEnvironmentVariable("database_connection");
            _tmdbService = new TMDBServiceImpl(_tmdbApiKey, log);

            log.LogInformation($"TMDBDataCollector function started at: {DateTime.Now}");
            log.LogInformation($"TMDBDataCollector retrieving localization codes started at: {DateTime.Now}");

            List<LocalizationCodes> localizationCodes = null;

            using (var databaseService = new DatabaseServiceImpl(_databaseConnection))
            {
                localizationCodes = databaseService.GetLocalizationCodes();
            }

            log.LogInformation($"TMDBDataCollector retrieving localization codes finished at: {DateTime.Now}");

            await _tmdbService.InitializeAsync();

            if (localizationCodes != null)
            {
                foreach (LocalizationCodes entry in localizationCodes)
                {
                    _tmdbService.Clear();

                    log.LogInformation($"TMDBDataCollector collecting data for language \"{entry.LanguageCode}\" started at: {DateTime.Now}");
                    _tmdbCollection = await DataCollector.CollectDataAsync(_tmdbService, entry.LanguageCode, entry.RegionCode);

                    log.LogInformation($"TMDBDataCollector filtering collections started at: {DateTime.Now}");
                    CollectionFilter.FilterCollections(_tmdbCollection);
                    log.LogInformation($"TMDBDataCollector filtering collections finished at: {DateTime.Now}");

                    WriteIntoDatabase(_tmdbCollection, log);
                    log.LogInformation($"TMDBDataCollector collecting data for language \"{entry.LanguageCode}\" finished at: {DateTime.Now}");
                }
            }

            log.LogInformation($"TMDBDataCollector function finished at: {DateTime.Now}");
        }

        private static void WriteIntoDatabase(TMDBCollection collection, ILogger logger)
        {
            logger.LogInformation($"TMDBDataCollector writing data into database started at: {DateTime.Now}");
            
            using IDatabaseService databaseService = new DatabaseServiceImpl(_databaseConnection);
            databaseService.SaveCollectedDataToDatabase(collection);
            
            logger.LogInformation($"TMDBDataCollector writing data into database finished at: {DateTime.Now}");
        }
    }
}
