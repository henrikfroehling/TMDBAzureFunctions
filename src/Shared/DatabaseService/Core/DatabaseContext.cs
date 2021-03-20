using Microsoft.EntityFrameworkCore;
using Models.Database;

namespace DatabaseService.Core
{
    public class DatabaseContext : DbContext
    {
        private readonly string _databaseConnection;

        public DatabaseContext(string databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public DbSet<ActionAdventureShowsAndMovies> ActionAdventureShowsAndMovies { get; set; }

        public DbSet<AnimationShowsAndMovies> AnimationShowsAndMovies { get; set; }

        public DbSet<AnimeShowsAndMovies> AnimeShowsAndMovies { get; set; }

        public DbSet<AnthologyShows> AnthologyShows { get; set; }

        public DbSet<ComedyShowsAndMovies> ComedyShowsAndMovies { get; set; }

        public DbSet<Configurations> Configurations { get; set; }

        public DbSet<CrimeShowsAndMovies> CrimeShowsAndMovies { get; set; }

        public DbSet<DocumentaryShowsAndMovies> DocumentaryShowsAndMovies { get; set; }

        public DbSet<DramaShowsAndMovies> DramaShowsAndMovies { get; set; }

        public DbSet<FamilyShowsAndMovies> FamilyShowsAndMovies { get; set; }

        public DbSet<FantasyMovies> FantasyMovies { get; set; }

        public DbSet<HistoricalDramaShowsAndMovies> HistoricalDramaShowsAndMovies { get; set; }

        public DbSet<HistoryShowsAndMovies> HistoryShowsAndMovies { get; set; }

        public DbSet<HorrorShowsAndMovies> HorrorShowsAndMovies { get; set; }

        public DbSet<KidsShowsAndMovies> KidsShowsAndMovies { get; set; }

        public DbSet<ListItems> ListItems { get; set; }

        public DbSet<MedicalDramaShowsAndMovies> MedicalDramaShowsAndMovies { get; set; }

        public DbSet<MovieGenres> MovieGenres { get; set; }

        public DbSet<MysteryShowsAndMovies> MysteryShowsAndMovies { get; set; }

        public DbSet<RomanceShowsAndMovies> RomanceShowsAndMovies { get; set; }

        public DbSet<ScifiShowsAndMovies> ScifiShowsAndMovies { get; set; }

        public DbSet<ShowGenres> ShowGenres { get; set; }

        public DbSet<SitcomShows> SitcomShows { get; set; }

        public DbSet<Snapshots> Snapshots { get; set; }

        public DbSet<TeenDramaShowsAndMovies> TeenDramaShowsAndMovies { get; set; }

        public DbSet<ThrillerShowsAndMovies> ThrillerShowsAndMovies { get; set; }

        public DbSet<TrendingShowsAndMovies> TrendingShowsAndMovies { get; set; }

        public DbSet<WarShowsAndMovies> WarShowsAndMovies { get; set; }

        public DbSet<WesternShowsAndMovies> WesternShowsAndMovies { get; set; }

        public DbSet<WorkplaceComedyShowsAndMovies> WorkplaceComedyShowsAndMovies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_databaseConnection,
                options => options.EnableRetryOnFailure());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionAdventureShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.ActionAdventureShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.ActionAdventureShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AnimationShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.AnimationShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.AnimationShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AnimeShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.AnimeShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.AnimeShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AnthologyShows>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.AnthologyShows)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.AnthologyShows)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ComedyShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.ComedyShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.ComedyShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Configurations>(entity =>
            {
                entity.Property(e => e.BackdropPathOriginal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BackdropPathW1280)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BackdropPathW300)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BackdropPathW780)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImageBasePath)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LogoPathOriginal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LogoPathW154)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LogoPathW185)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LogoPathW300)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LogoPathW45)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LogoPathW500)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LogoPathW92)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PosterPathOriginal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PosterPathW154)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PosterPathW185)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PosterPathW342)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PosterPathW500)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PosterPathW780)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PosterPathW92)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProfilePathH632)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProfilePathOriginal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProfilePathW185)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProfilePathW45)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StillPathOriginal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StillPathW185)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StillPathW300)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StillPathW92)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.Configurations)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CrimeShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.CrimeShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.CrimeShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DocumentaryShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.DocumentaryShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.DocumentaryShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DramaShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.DramaShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.DramaShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<FamilyShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.FamilyShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.FamilyShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<FantasyMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.FantasyMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.FantasyMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<HistoricalDramaShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.HistoricalDramaShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.HistoricalDramaShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<HistoryShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.HistoryShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.HistoryShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<HorrorShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.HorrorShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.HorrorShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<KidsShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.KidsShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.KidsShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ListItems>(entity =>
            {
                entity.Property(e => e.BackdropPathOriginal)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.BackdropPathW1280)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.BackdropPathW300)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.BackdropPathW780)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Overview)
                    .IsRequired()
                    .HasColumnType("NTEXT");

                entity.Property(e => e.PosterPathOriginal)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.PosterPathW154)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.PosterPathW185)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.PosterPathW342)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.PosterPathW500)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.PosterPathW780)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.PosterPathW92)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.ListItems)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MedicalDramaShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.MedicalDramaShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.MedicalDramaShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MovieGenres>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.MovieGenres)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MysteryShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.MysteryShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.MysteryShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<RomanceShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.RomanceShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.RomanceShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ScifiShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.ScifiShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.ScifiShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ShowGenres>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.ShowGenres)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SitcomShows>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.SitcomShows)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.SitcomShows)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Snapshots>(entity =>
            {
                entity.Property(e => e.TimeStamp)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("(GETUTCDATE())");

                entity.Property(e => e.LanguageCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.RegionCode)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.SnapshotAsJSON)
                    .IsRequired()
                    .HasColumnType("NTEXT");
            });

            modelBuilder.Entity<TeenDramaShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.TeenDramaShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.TeenDramaShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ThrillerShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.ThrillerShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.ThrillerShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TrendingShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.TrendingShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.TrendingShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WarShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.WarShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.WarShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WesternShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.WesternShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.WesternShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WorkplaceComedyShowsAndMovies>(entity =>
            {
                entity.HasOne(d => d.ListItem)
                    .WithMany(p => p.WorkplaceComedyShowsAndMovies)
                    .HasForeignKey(d => d.ListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Snapshot)
                    .WithMany(p => p.WorkplaceComedyShowsAndMovies)
                    .HasForeignKey(d => d.SnapshotId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
