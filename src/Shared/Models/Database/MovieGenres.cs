namespace Models.Database
{
    public class MovieGenres
    {
        public int Id { get; set; }
        
        public int GenreId { get; set; }
        
        public string Name { get; set; }
        
        public int SnapshotId { get; set; }

        public Snapshots Snapshot { get; set; }
    }
}
