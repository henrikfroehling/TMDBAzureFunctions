using CompressionService;
using DatabaseService;
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

        private static string _databaseConnection;

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
            _databaseConnection = Environment.GetEnvironmentVariable("database_connection");
            log.LogInformation($"TMDBDailyFileExportDownloader function started at: {DateTime.Now}");

            DeleteCurrentDailyDownloadsFromDatabase(log);

            List<DailyDownloadCollection> dailyDownloadCollections = null;
            List<DailyDownloadNetwork> dailyDownloadNetworks = null;
            List<DailyDownloadKeyword> dailyDownloadKeywords = null;

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

            WriteDailyDownloadsIntoDatabase(dailyDownloadCollections, dailyDownloadNetworks, dailyDownloadKeywords, log);

            log.LogInformation($"TMDBDailyFileExportDownloader function finished at: {DateTime.Now}");
        }

        private static string DownloadFile(FileType fileType, ILogger logger)
        {
            string downloadFilename = CreateDownloadFilename(fileType);

            if (!string.IsNullOrEmpty(downloadFilename))
            {
                using var webClient = new WebClient();
                var compressionService = new CompressionServiceImpl();

                try
                {
                    logger.LogInformation($"TMDBDailyFileExportDownloader downloading file \"{downloadFilename}\" started at: {DateTime.Now}");
                    byte[] fileData = webClient.DownloadData(downloadFilename);
                    logger.LogInformation($"TMDBDailyFileExportDownloader downloading file \"{downloadFilename}\" successfully finished at: {DateTime.Now}");

                    return compressionService.DecompressToJson(fileData);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"error on downloading \"{downloadFilename}\"");
                }
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

        private static void DeleteCurrentDailyDownloadsFromDatabase(ILogger logger)
        {
            logger.LogInformation($"TMDBDailyFileExportDownloader deleting current daily downloads from database started at: {DateTime.Now}");

            using var databaseService = new DatabaseServiceImpl(_databaseConnection);
            databaseService.DeleteDailyDownloads();

            logger.LogInformation($"TMDBDailyFileExportDownloader deleting current daily downloads from database finished at: {DateTime.Now}");
        }

        private static void WriteDailyDownloadsIntoDatabase(List<DailyDownloadCollection> dailyDownloadCollections, List<DailyDownloadNetwork> dailyDownloadNetworks,
                                                            List<DailyDownloadKeyword> dailyDownloadKeywords, ILogger logger)
        {
            logger.LogInformation($"TMDBDailyFileExportDownloader writing daily downloads into database started at: {DateTime.Now}");

            string dailyDownloadCollectionsJSON = string.Empty;
            string dailyDownloadNetworksJSON = string.Empty;
            string dailyDownloadKeywordsJSON = string.Empty;

            var compressionService = new CompressionServiceImpl();

            if (dailyDownloadCollections != null)
            {
                string json = JsonConvert.SerializeObject(dailyDownloadCollections);
                dailyDownloadCollectionsJSON = compressionService.CompressJSONAsBase64(json);
            }

            if (dailyDownloadNetworks != null)
            {
                string json = JsonConvert.SerializeObject(dailyDownloadNetworks);
                dailyDownloadNetworksJSON = compressionService.CompressJSONAsBase64(json);
            }

            if (dailyDownloadKeywords != null)
            {
                string json = JsonConvert.SerializeObject(dailyDownloadKeywords);
                dailyDownloadKeywordsJSON = compressionService.CompressJSONAsBase64(json);
            }

            if (!string.IsNullOrEmpty(dailyDownloadCollectionsJSON) && !string.IsNullOrEmpty(dailyDownloadNetworksJSON) && !string.IsNullOrEmpty(dailyDownloadKeywordsJSON))
            {
                using var databaseService = new DatabaseServiceImpl(_databaseConnection);
                databaseService.WriteDailyDownloadsIntoDatabase(dailyDownloadCollectionsJSON, dailyDownloadNetworksJSON, dailyDownloadKeywordsJSON);
            }

            logger.LogInformation($"TMDBDailyFileExportDownloader writing daily downloads into database finished at: {DateTime.Now}");
        }
    }
}
