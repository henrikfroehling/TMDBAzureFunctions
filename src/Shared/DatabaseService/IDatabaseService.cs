using Models.TMDB;
using System;

namespace DatabaseService
{
    public interface IDatabaseService : IDisposable
    {
        void SaveCollectedDataToDatabase(TMDBCollection collection);
    }
}
