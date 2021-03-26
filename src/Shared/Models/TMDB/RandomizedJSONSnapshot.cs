using System.Collections.Generic;

namespace Models.TMDB
{
    public class RandomizedJSONSnapshot
    {
        public Configuration Configuration { get; set; }

        public List<Genre> ShowGenres { get; set; }

        public List<Genre> MovieGenres { get; set; }

        public List<ListItem> TrendingShowsAndMovies { get; set; }

        public List<ListItem> ComedyShowsAndMovies { get; set; }

        public List<ListItem> DramaShowsAndMovies { get; set; }

        public List<ListItem> ActionAdventureShowsAndMovies { get; set; }

        public List<ListItem> AnimationShowsAndMovies { get; set; }

        public List<ListItem> ScifiShowsAndMovies { get; set; }

        public List<ListItem> CrimeShowsAndMovies { get; set; }

        public List<ListItem> MysteryShowsAndMovies { get; set; }

        public List<ListItem> ThrillerShowsAndMovies { get; set; }

        public List<ListItem> HorrorShowsAndMovies { get; set; }

        public List<ListItem> FamilyShowsAndMovies { get; set; }

        public List<ListItem> KidsShowsAndMovies { get; set; }

        public List<ListItem> WesternShowsAndMovies { get; set; }

        public List<ListItem> FantasyMovies { get; set; }

        public List<ListItem> HistoryShowsAndMovies { get; set; }

        public List<ListItem> RomanceShowsAndMovies { get; set; }

        public List<ListItem> WarShowsAndMovies { get; set; }

        public List<ListItem> DocumentaryShowsAndMovies { get; set; }

        public List<ListItem> SitcomShows { get; set; }

        public List<ListItem> AnthologyShows { get; set; }

        public List<ListItem> AnimeShowsAndMovies { get; set; }

        public List<ListItem> TeenDramaShowsAndMovies { get; set; }

        public List<ListItem> HistoricalDramaShowsAndMovies { get; set; }

        public List<ListItem> WorkplaceComedyShowsAndMovies { get; set; }

        public List<ListItem> MedicalDramaShowsAndMovies { get; set; }
    }
}
