using System.Collections.Generic;

namespace Models.TMDB
{
    public class BaseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }
       
        public string Tagline { get; set; }

        public List<Genre> Genres { get; set; }

        public List<string> GenreNames { get; set; }

        public string Status { get; set; }

        public float VoteAverage { get; set; }

        public int VoteCount { get; set; }

        public string Homepage { get; set; }

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

        public List<ProductionCompany> ProductionCompanies { get; set; }

        public List<ProductionCountry> ProductionCountries { get; set; }
    }
}
