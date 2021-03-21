using DatabaseService;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace TMDBDataCleaner
{
    public static class TMDBDataCleaner
    {
        private static string _databaseConnection;

        [FunctionName("TMDBDataCleaner")]
        public static void Run([TimerTrigger("0 0 0 * * *" /* runs every day */
#if DEBUG
            , RunOnStartup = true
#endif
            )]TimerInfo myTimer, ILogger log)
        {
            _databaseConnection = Environment.GetEnvironmentVariable("database_connection");
            log.LogInformation($"TMDBDataCleaner function started at: {DateTime.Now}");
            RemoveOldDataFromDatabase(log);
            log.LogInformation($"TMDBDataCleaner function finished at: {DateTime.Now}");
        }

        private static void RemoveOldDataFromDatabase(ILogger logger)
        {
            logger.LogInformation($"TMDBDataCleaner removing old data from database started at: {DateTime.Now}");
            using IDatabaseService databaseService = new DatabaseServiceImpl(_databaseConnection);
            databaseService.RemoveOldDataFromDatabase();
            logger.LogInformation($"TMDBDataCleaner removing old data from database finished at: {DateTime.Now}");
        }
    }
}
