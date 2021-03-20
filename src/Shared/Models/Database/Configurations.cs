namespace Models.Database
{
    public class Configurations
    {
        public int Id { get; set; }
        
        public string ImageBasePath { get; set; }
        
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
        
        public string ProfilePathOriginal { get; set; }
        
        public string ProfilePathH632 { get; set; }
        
        public string ProfilePathW185 { get; set; }
        
        public string ProfilePathW45 { get; set; }
        
        public string LogoPathOriginal { get; set; }
        
        public string LogoPathW500 { get; set; }
        
        public string LogoPathW300 { get; set; }
        
        public string LogoPathW185 { get; set; }
        
        public string LogoPathW154 { get; set; }
        
        public string LogoPathW92 { get; set; }
        
        public string LogoPathW45 { get; set; }
        
        public string StillPathOriginal { get; set; }
        
        public string StillPathW300 { get; set; }
        
        public string StillPathW185 { get; set; }
        
        public string StillPathW92 { get; set; }
        
        public int SnapshotId { get; set; }

        public Snapshots Snapshot { get; set; }
    }
}
