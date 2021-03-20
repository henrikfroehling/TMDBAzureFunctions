namespace Models.TMDBApi
{
    public class TMDBEpisodeToAirResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public int id { get; set; }

        public string name { get; set; }

        public string overview { get; set; }

        public int season_number { get; set; }

        public int episode_number { get; set; }

        public string air_date { get; set; }

        public string production_code { get; set; }
        
        public double vote_average { get; set; }
        
        public int vote_count { get; set; }

        public string still_path { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
