using System.Collections.Generic;

namespace Models.TMDBApi
{
    public class TMDBTopRatedMovieResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public int id { get; set; }

        public string title { get; set; }

        public string overview { get; set; }

        public List<int> genre_ids { get; set; }

        public string original_title { get; set; }

        public string original_language { get; set; }

        public double popularity { get; set; }

        public string backdrop_path { get; set; }

        public string poster_path { get; set; }

        public string release_date { get; set; }

        public bool adult { get; set; }
        
        public bool video { get; set; }
        
        public double vote_average { get; set; }
        
        public int vote_count { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
