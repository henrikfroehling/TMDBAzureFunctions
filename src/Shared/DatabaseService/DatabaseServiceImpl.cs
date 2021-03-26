using DatabaseService.Core;
using Models.Database;
using Models.TMDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseService
{
    public class DatabaseServiceImpl : IDatabaseService
    {
        private readonly string _databaseConnection = "";
        private readonly DatabaseContext _context;
        private bool _disposed = false;

        public DatabaseServiceImpl(string databaseConnection)
        {
            _databaseConnection = databaseConnection;
            _context = new DatabaseContext(_databaseConnection);
        }

        public List<LocalizationCodes> GetLocalizationCodes()
        {
            return _context.LocalizationCodes.ToList();
        }

        public void SaveCollectedDataToDatabase(TMDBSnapshot tmdbSnapshot)
        {
            var snapshot = new Snapshots
            {
                LanguageCode = tmdbSnapshot.LanguageCode,
                RegionCode = tmdbSnapshot.RegionCode,
                CompressedBase64JSONData = tmdbSnapshot.CompressedBase64JSONData
            };

            _context.Snapshots.Add(snapshot);
            _context.SaveChanges();
        }

        public void RemoveOldDataFromDatabase()
        {
            List<Snapshots> snapshots = _context.Snapshots.ToList();

            // Get all snapshots which are older than a day
            List<Snapshots> oldSnapshots = snapshots.Where(s => Math.Abs((s.TimeStamp - DateTime.UtcNow).TotalDays) > 1).ToList();
            _context.RemoveRange(oldSnapshots);
            _context.SaveChanges();
        }

        public void WriteDailyDownloadsIntoDatabase(string dailyDownloadCollectionsJSON, string dailyDownloadNetworksJSON, string dailyDownloadKeywordsJSON)
        {
            var dailyDownloads = new DailyDownloads
            {
                CollectionIdsCompressedBase64JSONData = dailyDownloadCollectionsJSON,
                NetworkIdsCompressedBase64JSONData = dailyDownloadNetworksJSON,
                KeywordIdsCompressedBase64JSONData = dailyDownloadKeywordsJSON
            };

            _context.DailyDownloads.Add(dailyDownloads);
            _context.SaveChanges();
        }

        public void DeleteDailyDownloads()
        {
            List<DailyDownloads> currentDailyDownloads = _context.DailyDownloads.ToList();
            _context.RemoveRange(currentDailyDownloads);
            _context.SaveChanges();
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _context.Dispose();

            _disposed = true;
        }
    }
}
