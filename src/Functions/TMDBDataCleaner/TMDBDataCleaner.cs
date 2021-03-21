using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace TMDBDataCleaner
{
    public static class TMDBDataCleaner
    {
        [FunctionName("TMDBDataCleaner")]
        public static void Run([TimerTrigger("0 0 0 * * *" /* runs every day */
#if DEBUG
            , RunOnStartup = true
#endif
            )]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"TMDBDataCleaner function started at: {DateTime.Now}");
        }
    }
}
