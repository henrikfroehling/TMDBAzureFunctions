namespace Models.TMDB
{
    public class ListItem
    {
        public ItemType ItemType { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }

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
    }
}
