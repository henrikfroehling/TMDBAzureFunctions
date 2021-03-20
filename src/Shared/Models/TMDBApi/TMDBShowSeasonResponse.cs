namespace Models.TMDBApi
{
    public class TMDBShowSeasonResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public int id { get; set; }

        public string name { get; set; }

        public string overview { get; set; }

        public int season_number { get; set; }

        public int episode_count { get; set; }

        public string air_date { get; set; }
        
        public string poster_path { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
