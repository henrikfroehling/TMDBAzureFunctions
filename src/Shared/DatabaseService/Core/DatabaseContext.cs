using Microsoft.EntityFrameworkCore;
using Models.Database;

namespace DatabaseService.Core
{
    public class DatabaseContext : DbContext
    {
        private readonly string _databaseConnection;

        public DatabaseContext(string databaseConnection) : base()
        {
            _databaseConnection = databaseConnection;
            Database.SetCommandTimeout(3600);
        }

        public DbSet<Snapshots> Snapshots { get; set; }

        public DbSet<DailyDownloads> DailyDownloads { get; set; }

        public DbSet<LocalizationCodes> LocalizationCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_databaseConnection,
                options => options.EnableRetryOnFailure());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

                entity.Property(e => e.CompressedBase64JSONData)
                    .IsRequired()
                    .HasColumnType("NTEXT");
            });

            modelBuilder.Entity<DailyDownloads>(entity =>
            {
                entity.Property(e => e.CollectionIdsCompressedBase64JSONData)
                    .IsRequired()
                    .HasColumnType("NTEXT");

                entity.Property(e => e.NetworkIdsCompressedBase64JSONData)
                    .IsRequired()
                    .HasColumnType("NTEXT");

                entity.Property(e => e.KeywordIdsCompressedBase64JSONData)
                    .IsRequired()
                    .HasColumnType("NTEXT");
            });

            modelBuilder.Entity<LocalizationCodes>(entity =>
            {
                entity.Property(e => e.LanguageCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.RegionCode)
                    .IsRequired()
                    .HasMaxLength(5);
            });
        }
    }
}
