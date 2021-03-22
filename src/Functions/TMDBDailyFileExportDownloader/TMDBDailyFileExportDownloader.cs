using CompressionService;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Models.TMDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace TMDBDailyFileExportDownloader
{
    public static class TMDBDailyFileExportDownloader
    {
        private enum FileType
        {
            COLLECTION_IDS,
            NETWORK_IDS,
            KEYWORD_IDS
        }

        private const string FILE_EXPORT_BASE_PATH = "http://files.tmdb.org/p/exports/";
        private const string COLLECTION_IDS_EXPORT_SUBPATH = "collection_ids_";
        private const string NETWORK_IDS_EXPORT_SUBPATH = "tv_network_ids_";
        private const string KEYWORD_IDS_EXPORT_SUBPATH = "keyword_ids_";
        private const string EXPORT_FILE_EXTENSION = ".json.gz";

        private static readonly List<FileType> FILE_TYPES = new List<FileType>
        {
            FileType.COLLECTION_IDS,
            FileType.NETWORK_IDS,
            FileType.KEYWORD_IDS
        };

        [FunctionName("TMDBDailyFileExportDownloader")]
        public static void Run([TimerTrigger("0 0 0 * * *" /* runs every day */
#if DEBUG
            , RunOnStartup = true
#endif
            )]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"TMDBDailyFileExportDownloader function started at: {DateTime.Now}");

            List<DailyDownloadCollection> dailyDownloadCollections;
            List<DailyDownloadNetwork> dailyDownloadNetworks;
            List<DailyDownloadKeyword> dailyDownloadKeywords;

            foreach (FileType fileType in FILE_TYPES)
            {
                string json = DownloadFile(fileType, log);

                if (!string.IsNullOrEmpty(json))
                {
                    switch (fileType)
                    {
                        case FileType.COLLECTION_IDS:
                            dailyDownloadCollections = DeserializeJSON<DailyDownloadCollection>(json);
                            break;
                        case FileType.NETWORK_IDS:
                            dailyDownloadNetworks = DeserializeJSON<DailyDownloadNetwork>(json);
                            break;
                        case FileType.KEYWORD_IDS:
                            dailyDownloadKeywords = DeserializeJSON<DailyDownloadKeyword>(json);
                            break;
                    }
                }
            }

            log.LogInformation($"TMDBDailyFileExportDownloader function finished at: {DateTime.Now}");
        }

        private static string DownloadFile(FileType fileType, ILogger logger)
        {
            string downloadFilename = CreateDownloadFilename(fileType);

            if (!string.IsNullOrEmpty(downloadFilename))
            {
                using var webClient = new WebClient();
                var compressionService = new CompressionServiceImpl();

                logger.LogInformation($"TMDBDailyFileExportDownloader downloading file \"{downloadFilename}\" started at: {DateTime.Now}");
                byte[] fileData = webClient.DownloadData(downloadFilename);
                logger.LogInformation($"TMDBDailyFileExportDownloader downloading file \"{downloadFilename}\" successfully finished at: {DateTime.Now}");

                return compressionService.DecompressToJson(fileData);
            }

            return string.Empty;
        }

        private static string CreateDownloadFilename(FileType fileType)
        {
            string currentDay = DateTime.Today.ToString("MM_dd_yyyy");
            string subPath;

            switch (fileType)
            {
                case FileType.COLLECTION_IDS:
                    subPath = COLLECTION_IDS_EXPORT_SUBPATH;
                    break;
                case FileType.NETWORK_IDS:
                    subPath = NETWORK_IDS_EXPORT_SUBPATH;
                    break;
                case FileType.KEYWORD_IDS:
                    subPath = KEYWORD_IDS_EXPORT_SUBPATH;
                    break;
                default:
                    return string.Empty;
            }

            return FILE_EXPORT_BASE_PATH + subPath + currentDay + EXPORT_FILE_EXTENSION;
        }

        private static List<T> DeserializeJSON<T>(string json)
        {
            string[] jsonLines = json.Split('\n');
            var dailyDownloadItems = new List<T>();

            foreach (string line in jsonLines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var dailyDownloadItem = JsonConvert.DeserializeObject<T>(line);
                    dailyDownloadItems.Add(dailyDownloadItem);
                }
            }

            return dailyDownloadItems;
        }
    }
}
