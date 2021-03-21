using Models.Database;
using Models.TMDB;
using System;
using System.Collections.Generic;

namespace DatabaseService
{
    public interface IDatabaseService : IDisposable
    {
        List<LocalizationCodes> GetLocalizationCodes();

        void SaveCollectedDataToDatabase(TMDBCollection collection);

        void RemoveOldDataFromDatabase();
    }
}
