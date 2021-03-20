namespace Models.Database
{
    public class CrimeShowsAndMovies
    {
        public int Id { get; set; }

        public int ListItemId { get; set; }

        public int SnapshotId { get; set; }

        public ListItems ListItem { get; set; }

        public Snapshots Snapshot { get; set; }
    }
}
