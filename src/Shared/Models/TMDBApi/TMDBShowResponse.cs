using System.Collections.Generic;

namespace Models.TMDBApi
{
    public class TMDBShowResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public int id { get; set; }

        public string name { get; set; }

        public string overview { get; set; }

        public string tagline { get; set; }

        public List<TMDBGenreResponse> genres { get; set; }

        public string original_name { get; set; }

        public string original_language { get; set; }

        public string first_air_date { get; set; }

        public string last_air_date { get; set; }

        public List<int> episode_run_time { get; set; }

        public int number_of_seasons { get; set; }

        public int number_of_episodes { get; set; }

        public TMDBEpisodeToAirResponse last_episode_to_air { get; set; }

        public TMDBEpisodeToAirResponse next_episode_to_air { get; set; }

        public List<TMDBShowSeasonResponse> seasons { get; set; }

        public List<TMDBNetworkResponse> networks { get; set; }

        public List<TMDBCreatedByResponse> created_by { get; set; }
        
        public List<TMDBProductionCompanyResponse> production_companies { get; set; }
        
        public List<TMDBProductionCountryResponse> production_countries { get; set; }
        
        public List<TMDBSpokenLanguageResponse> spoken_languages { get; set; }

        public List<string> languages { get; set; }

        public List<string> origin_country { get; set; }

        public bool in_production { get; set; }

        public string status { get; set; }
        
        public string type { get; set; }

        public string homepage { get; set; }

        public double popularity { get; set; }

        public double vote_average { get; set; }
        
        public int vote_count { get; set; }

        public string backdrop_path { get; set; }

        public string poster_path { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
