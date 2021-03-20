using System.Collections.Generic;

namespace Models.Database
{
    public class ListItems
    {
        public ListItems()
        {
            ActionAdventureShowsAndMovies = new HashSet<ActionAdventureShowsAndMovies>();
            AnimationShowsAndMovies = new HashSet<AnimationShowsAndMovies>();
            AnimeShowsAndMovies = new HashSet<AnimeShowsAndMovies>();
            AnthologyShows = new HashSet<AnthologyShows>();
            ComedyShowsAndMovies = new HashSet<ComedyShowsAndMovies>();
            CrimeShowsAndMovies = new HashSet<CrimeShowsAndMovies>();
            DocumentaryShowsAndMovies = new HashSet<DocumentaryShowsAndMovies>();
            DramaShowsAndMovies = new HashSet<DramaShowsAndMovies>();
            FamilyShowsAndMovies = new HashSet<FamilyShowsAndMovies>();
            FantasyMovies = new HashSet<FantasyMovies>();
            HistoricalDramaShowsAndMovies = new HashSet<HistoricalDramaShowsAndMovies>();
            HistoryShowsAndMovies = new HashSet<HistoryShowsAndMovies>();
            HorrorShowsAndMovies = new HashSet<HorrorShowsAndMovies>();
            KidsShowsAndMovies = new HashSet<KidsShowsAndMovies>();
            MedicalDramaShowsAndMovies = new HashSet<MedicalDramaShowsAndMovies>();
            MysteryShowsAndMovies = new HashSet<MysteryShowsAndMovies>();
            RomanceShowsAndMovies = new HashSet<RomanceShowsAndMovies>();
            ScifiShowsAndMovies = new HashSet<ScifiShowsAndMovies>();
            SitcomShows = new HashSet<SitcomShows>();
            TeenDramaShowsAndMovies = new HashSet<TeenDramaShowsAndMovies>();
            ThrillerShowsAndMovies = new HashSet<ThrillerShowsAndMovies>();
            TrendingShowsAndMovies = new HashSet<TrendingShowsAndMovies>();
            WarShowsAndMovies = new HashSet<WarShowsAndMovies>();
            WesternShowsAndMovies = new HashSet<WesternShowsAndMovies>();
            WorkplaceComedyShowsAndMovies = new HashSet<WorkplaceComedyShowsAndMovies>();
        }

        public int Id { get; set; }

        public int ItemType { get; set; }

        public int ItemId { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }

        public string BackdropPathOriginal { get; set; }

        public string BackdropPathW1280 { get; set; }

        public string BackdropPathW780 { get; set; }

        public string BackdropPathW300 { get; set; }

        public string PosterPathOriginal { get; set; }

        public string PosterPathW780 { get; set; }

        public string PosterPathW500 { get; set; }

        public string PosterPathW342 { get; set; }

        public string PosterPathW185 { get; set; }

        public string PosterPathW154 { get; set; }

        public string PosterPathW92 { get; set; }

        public int SnapshotId { get; set; }

        public Snapshots Snapshot { get; set; }

        public ICollection<ActionAdventureShowsAndMovies> ActionAdventureShowsAndMovies { get; set; }

        public ICollection<AnimationShowsAndMovies> AnimationShowsAndMovies { get; set; }

        public ICollection<AnimeShowsAndMovies> AnimeShowsAndMovies { get; set; }

        public ICollection<AnthologyShows> AnthologyShows { get; set; }

        public ICollection<ComedyShowsAndMovies> ComedyShowsAndMovies { get; set; }

        public ICollection<CrimeShowsAndMovies> CrimeShowsAndMovies { get; set; }

        public ICollection<DocumentaryShowsAndMovies> DocumentaryShowsAndMovies { get; set; }

        public ICollection<DramaShowsAndMovies> DramaShowsAndMovies { get; set; }

        public ICollection<FamilyShowsAndMovies> FamilyShowsAndMovies { get; set; }

        public ICollection<FantasyMovies> FantasyMovies { get; set; }

        public ICollection<HistoricalDramaShowsAndMovies> HistoricalDramaShowsAndMovies { get; set; }

        public ICollection<HistoryShowsAndMovies> HistoryShowsAndMovies { get; set; }

        public ICollection<HorrorShowsAndMovies> HorrorShowsAndMovies { get; set; }

        public ICollection<KidsShowsAndMovies> KidsShowsAndMovies { get; set; }

        public ICollection<MedicalDramaShowsAndMovies> MedicalDramaShowsAndMovies { get; set; }

        public ICollection<MysteryShowsAndMovies> MysteryShowsAndMovies { get; set; }

        public ICollection<RomanceShowsAndMovies> RomanceShowsAndMovies { get; set; }

        public ICollection<ScifiShowsAndMovies> ScifiShowsAndMovies { get; set; }

        public ICollection<SitcomShows> SitcomShows { get; set; }

        public ICollection<TeenDramaShowsAndMovies> TeenDramaShowsAndMovies { get; set; }

        public ICollection<ThrillerShowsAndMovies> ThrillerShowsAndMovies { get; set; }

        public ICollection<TrendingShowsAndMovies> TrendingShowsAndMovies { get; set; }

        public ICollection<WarShowsAndMovies> WarShowsAndMovies { get; set; }

        public ICollection<WesternShowsAndMovies> WesternShowsAndMovies { get; set; }

        public ICollection<WorkplaceComedyShowsAndMovies> WorkplaceComedyShowsAndMovies { get; set; }
    }
}
