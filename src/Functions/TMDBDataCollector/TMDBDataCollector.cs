using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Models.TMDB;
using System;
using System.Threading.Tasks;
using TMDBDataCollector.Utils;
using TMDBService;

namespace TMDBDataCollector
{
    public static class TMDBDataCollector
    {
        private static ITMDBService _tmdbService;
        private static TMDBCollection _tmdbCollection;

        [FunctionName("TMDBDataCollector")]
        public static async Task Run([TimerTrigger("0 0 * * * *" /* runs every hour */
#if DEBUG
            , RunOnStartup = true
#endif
            )]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"TMDBDataCollector function started at: {DateTime.Now}");

            _tmdbService = new TMDBServiceImpl(log);
            await _tmdbService.InitializeAsync();
            _tmdbCollection = await DataCollector.CollectDataAsync(_tmdbService);

            log.LogInformation($"TMDBDataCollector filtering collections started at: {DateTime.Now}");
            CollectionFilter.FilterCollections(_tmdbCollection);
            log.LogInformation($"TMDBDataCollector filtering collections finished at: {DateTime.Now}");

            log.LogInformation($"TMDBDataCollector function finished at: {DateTime.Now}");
        }
    }
}
