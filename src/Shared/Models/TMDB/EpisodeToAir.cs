namespace Models.TMDB
{
    public class EpisodeToAir
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Overview { get; set; }

        public int SeasonNumber { get; set; }

        public int EpisodeNumber { get; set; }

        public string AirDate { get; set; }

        public float VoteAverage { get; set; }

        public int VoteCount { get; set; }

        public string StillPathOriginal { get; set; }

        public string StillPathW300 { get; set; }

        public string StillPathW185 { get; set; }

        public string StillPathW92 { get; set; }
    }
}
