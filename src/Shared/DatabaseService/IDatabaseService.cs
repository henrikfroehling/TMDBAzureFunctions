using Models.Database;
using Models.TMDB;
using System;
using System.Collections.Generic;

namespace DatabaseService
{
    public interface IDatabaseService : IDisposable
    {
        List<LocalizationCodes> GetLocalizationCodes();

        void SaveCollectedDataToDatabase(TMDBSnapshot tmdbSnapshot);

        void RemoveOldDataFromDatabase();

        void WriteDailyDownloadsIntoDatabase(string dailyDownloadCollectionsJSON, string dailyDownloadNetworksJSON, string dailyDownloadKeywordsJSON);

        void DeleteDailyDownloads();
    }
}
