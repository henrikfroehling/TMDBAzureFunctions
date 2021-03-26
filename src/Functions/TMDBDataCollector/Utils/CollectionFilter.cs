using Microsoft.Extensions.Logging;
using Models.TMDB;
using System;
using System.Collections.Generic;

namespace TMDBDataCollector.Utils
{
    public static class CollectionFilter
    {
        public static void FilterCollections(TMDBSnapshot tmdbSnapshot, ILogger logger)
        {
            logger.LogInformation($"TMDBDataCollector filtering collections started at: {DateTime.Now}");

            if (tmdbSnapshot != null)
            {
                FilterCollection(tmdbSnapshot.PopularShowsAndMovies);
                FilterCollection(tmdbSnapshot.ComedyShowsAndMovies);
                FilterCollection(tmdbSnapshot.DramaShowsAndMovies);
                FilterCollection(tmdbSnapshot.ActionAdventureShowsAndMovies);
                FilterCollection(tmdbSnapshot.AnimationShowsAndMovies);
                FilterCollection(tmdbSnapshot.ScifiShowsAndMovies);
                FilterCollection(tmdbSnapshot.CrimeShowsAndMovies);
                FilterCollection(tmdbSnapshot.MysteryShowsAndMovies);
                FilterCollection(tmdbSnapshot.ThrillerShowsAndMovies);
                FilterCollection(tmdbSnapshot.HorrorShowsAndMovies);
                FilterCollection(tmdbSnapshot.FamilyShowsAndMovies);
                FilterCollection(tmdbSnapshot.KidsShowsAndMovies);
                FilterCollection(tmdbSnapshot.WesternShowsAndMovies);
                FilterCollection(tmdbSnapshot.FantasyMovies);
                FilterCollection(tmdbSnapshot.HistoryShowsAndMovies);
                FilterCollection(tmdbSnapshot.RomanceShowsAndMovies);
                FilterCollection(tmdbSnapshot.WarShowsAndMovies);
                FilterCollection(tmdbSnapshot.DocumentaryShowsAndMovies);
                FilterCollection(tmdbSnapshot.SitcomShows);
                FilterCollection(tmdbSnapshot.AnthologyShows);
                FilterCollection(tmdbSnapshot.AnimeShowsAndMovies);
                FilterCollection(tmdbSnapshot.TeenDramaShowsAndMovies);
                FilterCollection(tmdbSnapshot.HistoricalDramaShowsAndMovies);
                FilterCollection(tmdbSnapshot.WorkplaceComedyShowsAndMovies);
                FilterCollection(tmdbSnapshot.MedicalDramaShowsAndMovies);
            }

            logger.LogInformation($"TMDBDataCollector filtering collections finished at: {DateTime.Now}");
        }

        private static void FilterCollection(List<ListItem> collection)
        {
            if (collection != null)
            {
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    ListItem item = collection[i];

                    if (IsBackdropPathEmpty(item) || IsPosterPathEmpty(item))
                        collection.RemoveAt(i);
                }
            }
        }

        private static bool IsBackdropPathEmpty(ListItem item)
        {
            return string.IsNullOrWhiteSpace(item.BackdropPathOriginal)
                || string.IsNullOrWhiteSpace(item.BackdropPathW1280)
                || string.IsNullOrWhiteSpace(item.BackdropPathW780)
                || string.IsNullOrWhiteSpace(item.BackdropPathW300);
        }

        private static bool IsPosterPathEmpty(ListItem item)
        {
            return string.IsNullOrWhiteSpace(item.PosterPathOriginal)
                || string.IsNullOrWhiteSpace(item.PosterPathW780)
                || string.IsNullOrWhiteSpace(item.PosterPathW500)
                || string.IsNullOrWhiteSpace(item.PosterPathW342)
                || string.IsNullOrWhiteSpace(item.PosterPathW185)
                || string.IsNullOrWhiteSpace(item.PosterPathW154)
                || string.IsNullOrWhiteSpace(item.PosterPathW92);
        }
    }
}
