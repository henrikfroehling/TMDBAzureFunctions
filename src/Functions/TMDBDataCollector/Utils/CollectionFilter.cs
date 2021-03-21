using Microsoft.Extensions.Logging;
using Models.TMDB;
using System;
using System.Collections.Generic;

namespace TMDBDataCollector.Utils
{
    public static class CollectionFilter
    {
        public static void FilterCollections(TMDBCollection collection, ILogger logger)
        {
            logger.LogInformation($"TMDBDataCollector filtering collections started at: {DateTime.Now}");

            if (collection != null)
            {
                FilterCollection(collection.TrendingShowsAndMovies);
                FilterCollection(collection.ComedyShowsAndMovies);
                FilterCollection(collection.DramaShowsAndMovies);
                FilterCollection(collection.ActionAdventureShowsAndMovies);
                FilterCollection(collection.AnimationShowsAndMovies);
                FilterCollection(collection.ScifiShowsAndMovies);
                FilterCollection(collection.CrimeShowsAndMovies);
                FilterCollection(collection.MysteryShowsAndMovies);
                FilterCollection(collection.ThrillerShowsAndMovies);
                FilterCollection(collection.HorrorShowsAndMovies);
                FilterCollection(collection.FamilyShowsAndMovies);
                FilterCollection(collection.KidsShowsAndMovies);
                FilterCollection(collection.WesternShowsAndMovies);
                FilterCollection(collection.FantasyMovies);
                FilterCollection(collection.HistoryShowsAndMovies);
                FilterCollection(collection.RomanceShowsAndMovies);
                FilterCollection(collection.WarShowsAndMovies);
                FilterCollection(collection.DocumentaryShowsAndMovies);
                FilterCollection(collection.SitcomShows);
                FilterCollection(collection.AnthologyShows);
                FilterCollection(collection.AnimeShowsAndMovies);
                FilterCollection(collection.TeenDramaShowsAndMovies);
                FilterCollection(collection.HistoricalDramaShowsAndMovies);
                FilterCollection(collection.WorkplaceComedyShowsAndMovies);
                FilterCollection(collection.MedicalDramaShowsAndMovies);
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
