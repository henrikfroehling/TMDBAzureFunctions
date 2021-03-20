using System.Collections.Generic;

namespace Models.TMDBApi
{
    public class TMDBMovieResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public int id { get; set; }

        public string title { get; set; }

        public string overview { get; set; }

        public string tagline { get; set; }

        public List<TMDBGenreResponse> genres { get; set; }

        public string original_title { get; set; }

        public string original_language { get; set; }

        public string release_date { get; set; }

        public int runtime { get; set; }

        public int budget { get; set; }

        public int revenue { get; set; }
        
        public TMDBBelongsToCollectionResponse belongs_to_collection { get; set; }
        
        public List<TMDBProductionCompanyResponse> production_companies { get; set; }
        
        public List<TMDBProductionCountryResponse> production_countries { get; set; }
        
        public List<TMDBSpokenLanguageResponse> spoken_languages { get; set; }
        
        public string status { get; set; }

        public string homepage { get; set; }

        public bool video { get; set; }

        public string imdb_id { get; set; }

        public double popularity { get; set; }

        public bool adult { get; set; }

        public double vote_average { get; set; }
        
        public int vote_count { get; set; }

        public string backdrop_path { get; set; }

        public string poster_path { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
