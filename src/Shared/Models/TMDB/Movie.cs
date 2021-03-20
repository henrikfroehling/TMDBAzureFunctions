namespace Models.TMDB
{
    public class Movie : BaseModel
    {
        public int Runtime { get; set; }

        public string ReleaseDate { get; set; }

        public int ReleaseYear { get; set; }

        public BelongsToCollection BelongsToCollection { get; set; }
    }
}
