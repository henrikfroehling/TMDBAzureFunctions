using System.Collections.Generic;

namespace Models.TMDB
{
    public class Show : BaseModel
    {
        public List<Network> Networks { get; set; }

        public List<int> EpisodeRuntimes { get; set; }

        public int SeasonCount { get; set; }

        public int EpisodeCount { get; set; }

        public List<ShowSeason> Seasons { get; set; }

        public string Type { get; set; }

        public string FirstAirDate { get; set; }

        public int FirstAirYear { get; set; }

        public string LastAirDate { get; set; }

        public int LastAirYear { get; set; }

        public EpisodeToAir LastEpisodeToAir { get; set; }

        public EpisodeToAir NextEpisodeToAir { get; set; }
    }
}
