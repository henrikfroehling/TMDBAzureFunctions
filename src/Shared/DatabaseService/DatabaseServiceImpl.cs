using DatabaseService.Core;
using Models.Database;
using Models.TMDB;
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

        public void SaveCollectedDataToDatabase(TMDBCollection collection)
        {
            var snapshot = new Snapshots
            {
                LanguageCode = collection.LanguageCode,
                RegionCode = collection.RegionCode,
                CompressedBase64JSONData = collection.CompressedBase64JSONData
            };

            AddConfiguration(snapshot, collection);
            AddShowGenres(snapshot, collection);
            AddMovieGenres(snapshot, collection);
            AddListItems(snapshot, collection);

            _context.Snapshots.Add(snapshot);
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

        private void AddConfiguration(Snapshots snapshot, TMDBCollection collection)
        {
            snapshot.Configurations.Add(new Configurations
            {
                ImageBasePath = collection.Configuration.SecureBaseUrl,
                BackdropPathW300 = collection.Configuration.BackdropSizes[(int)BackdropQuality.W300],
                BackdropPathW780 = collection.Configuration.BackdropSizes[(int)BackdropQuality.W780],
                BackdropPathW1280 = collection.Configuration.BackdropSizes[(int)BackdropQuality.W1280],
                BackdropPathOriginal = collection.Configuration.BackdropSizes[(int)BackdropQuality.Original],
                PosterPathW92 = collection.Configuration.PosterSizes[(int)PosterQuality.W92],
                PosterPathW154 = collection.Configuration.PosterSizes[(int)PosterQuality.W154],
                PosterPathW185 = collection.Configuration.PosterSizes[(int)PosterQuality.W185],
                PosterPathW342 = collection.Configuration.PosterSizes[(int)PosterQuality.W342],
                PosterPathW500 = collection.Configuration.PosterSizes[(int)PosterQuality.W500],
                PosterPathW780 = collection.Configuration.PosterSizes[(int)PosterQuality.W780],
                PosterPathOriginal = collection.Configuration.PosterSizes[(int)PosterQuality.Original],
                ProfilePathW45 = collection.Configuration.ProfileSizes[(int)ProfileQuality.W45],
                ProfilePathW185 = collection.Configuration.ProfileSizes[(int)ProfileQuality.W185],
                ProfilePathH632 = collection.Configuration.ProfileSizes[(int)ProfileQuality.H632],
                ProfilePathOriginal = collection.Configuration.ProfileSizes[(int)ProfileQuality.Original],
                LogoPathW45 = collection.Configuration.LogoSizes[(int)LogoQuality.W45],
                LogoPathW92 = collection.Configuration.LogoSizes[(int)LogoQuality.W92],
                LogoPathW154 = collection.Configuration.LogoSizes[(int)LogoQuality.W154],
                LogoPathW185 = collection.Configuration.LogoSizes[(int)LogoQuality.W185],
                LogoPathW300 = collection.Configuration.LogoSizes[(int)LogoQuality.W300],
                LogoPathW500 = collection.Configuration.LogoSizes[(int)LogoQuality.W500],
                LogoPathOriginal = collection.Configuration.LogoSizes[(int)LogoQuality.Original],
                StillPathW92 = collection.Configuration.StillSizes[(int)StillQuality.W92],
                StillPathW185 = collection.Configuration.StillSizes[(int)StillQuality.W185],
                StillPathW300 = collection.Configuration.StillSizes[(int)StillQuality.W300],
                StillPathOriginal = collection.Configuration.StillSizes[(int)StillQuality.Original]
            });
        }

        private void AddShowGenres(Snapshots snapshot, TMDBCollection collection)
        {
            foreach (Genre genre in collection.ShowGenres)
            {
                snapshot.ShowGenres.Add(new ShowGenres
                {
                    GenreId = genre.Id,
                    Name = genre.Name
                });
            }
        }

        private void AddMovieGenres(Snapshots snapshot, TMDBCollection collection)
        {
            foreach (Genre genre in collection.MovieGenres)
            {
                snapshot.MovieGenres.Add(new MovieGenres
                {
                    GenreId = genre.Id,
                    Name = genre.Name
                });
            }
        }

        private void AddListItems(Snapshots snapshot, TMDBCollection collection)
        {
            var listItems = new Dictionary<int, ListItems>();

            FillListItemsUniquely(listItems, collection.ActionAdventureShowsAndMovies);
            FillListItemsUniquely(listItems, collection.AnimationShowsAndMovies);
            FillListItemsUniquely(listItems, collection.AnimeShowsAndMovies);
            FillListItemsUniquely(listItems, collection.AnthologyShows);
            FillListItemsUniquely(listItems, collection.ComedyShowsAndMovies);
            FillListItemsUniquely(listItems, collection.CrimeShowsAndMovies);
            FillListItemsUniquely(listItems, collection.DocumentaryShowsAndMovies);
            FillListItemsUniquely(listItems, collection.DramaShowsAndMovies);
            FillListItemsUniquely(listItems, collection.FamilyShowsAndMovies);
            FillListItemsUniquely(listItems, collection.FantasyMovies);
            FillListItemsUniquely(listItems, collection.HistoricalDramaShowsAndMovies);
            FillListItemsUniquely(listItems, collection.HistoryShowsAndMovies);
            FillListItemsUniquely(listItems, collection.HorrorShowsAndMovies);
            FillListItemsUniquely(listItems, collection.KidsShowsAndMovies);
            FillListItemsUniquely(listItems, collection.MedicalDramaShowsAndMovies);
            FillListItemsUniquely(listItems, collection.MysteryShowsAndMovies);
            FillListItemsUniquely(listItems, collection.RomanceShowsAndMovies);
            FillListItemsUniquely(listItems, collection.ScifiShowsAndMovies);
            FillListItemsUniquely(listItems, collection.SitcomShows);
            FillListItemsUniquely(listItems, collection.TeenDramaShowsAndMovies);
            FillListItemsUniquely(listItems, collection.ThrillerShowsAndMovies);
            FillListItemsUniquely(listItems, collection.TrendingShowsAndMovies);
            FillListItemsUniquely(listItems, collection.WarShowsAndMovies);
            FillListItemsUniquely(listItems, collection.WesternShowsAndMovies);
            FillListItemsUniquely(listItems, collection.WorkplaceComedyShowsAndMovies);

            FillSnapshotCollections(snapshot, collection, listItems);

            foreach (ListItems item in listItems.Values)
                snapshot.ListItems.Add(item);
        }

        private void FillListItemsUniquely(Dictionary<int, ListItems> listItems, List<ListItem> collectionItems)
        {
            foreach (ListItem item in collectionItems)
            {
                if (!listItems.ContainsKey(item.Id))
                {
                    listItems.Add(item.Id, new ListItems
                    {
                        ItemId = item.Id,
                        ItemType = (int)item.ItemType,
                        Title = item.Title,
                        Overview = item.Overview,
                        BackdropPathOriginal = item.BackdropPathOriginal,
                        BackdropPathW1280 = item.BackdropPathW1280,
                        BackdropPathW780 = item.BackdropPathW780,
                        BackdropPathW300 = item.BackdropPathW300,
                        PosterPathOriginal = item.PosterPathOriginal,
                        PosterPathW780 = item.PosterPathW780,
                        PosterPathW500 = item.PosterPathW500,
                        PosterPathW342 = item.PosterPathW342,
                        PosterPathW185 = item.PosterPathW185,
                        PosterPathW154 = item.PosterPathW154,
                        PosterPathW92 = item.PosterPathW92
                    });
                }
            }
        }

        private void FillSnapshotCollections(Snapshots snapshot, TMDBCollection collection, Dictionary<int, ListItems> listItems)
        {
            foreach (ListItem item in collection.ActionAdventureShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.ActionAdventureShowsAndMovies.Add(new ActionAdventureShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.AnimationShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.AnimationShowsAndMovies.Add(new AnimationShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.AnimeShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.AnimeShowsAndMovies.Add(new AnimeShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.AnthologyShows)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.AnthologyShows.Add(new AnthologyShows { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.ComedyShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.ComedyShowsAndMovies.Add(new ComedyShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.CrimeShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.CrimeShowsAndMovies.Add(new CrimeShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.DocumentaryShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.DocumentaryShowsAndMovies.Add(new DocumentaryShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.DramaShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.DramaShowsAndMovies.Add(new DramaShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.FamilyShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.FamilyShowsAndMovies.Add(new FamilyShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.FantasyMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.FantasyMovies.Add(new FantasyMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.HistoricalDramaShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.HistoricalDramaShowsAndMovies.Add(new HistoricalDramaShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.HistoryShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.HistoryShowsAndMovies.Add(new HistoryShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.HorrorShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.HorrorShowsAndMovies.Add(new HorrorShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.KidsShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.KidsShowsAndMovies.Add(new KidsShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.MedicalDramaShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.MedicalDramaShowsAndMovies.Add(new MedicalDramaShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.MysteryShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.MysteryShowsAndMovies.Add(new MysteryShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.RomanceShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.RomanceShowsAndMovies.Add(new RomanceShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.ScifiShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.ScifiShowsAndMovies.Add(new ScifiShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.SitcomShows)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.SitcomShows.Add(new SitcomShows { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.TeenDramaShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.TeenDramaShowsAndMovies.Add(new TeenDramaShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.ThrillerShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.ThrillerShowsAndMovies.Add(new ThrillerShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.TrendingShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.TrendingShowsAndMovies.Add(new TrendingShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.WarShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.WarShowsAndMovies.Add(new WarShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.WesternShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.WesternShowsAndMovies.Add(new WesternShowsAndMovies { ListItem = listItems[item.Id] });
            }

            foreach (ListItem item in collection.WorkplaceComedyShowsAndMovies)
            {
                if (listItems.ContainsKey(item.Id))
                    snapshot.WorkplaceComedyShowsAndMovies.Add(new WorkplaceComedyShowsAndMovies { ListItem = listItems[item.Id] });
            }
        }
    }
}
