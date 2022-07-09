namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Performer> Performers { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<SongPerformer> SongsPerformers { get; set; }

        public DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Album

            //SongPerformer
            builder.Entity<SongPerformer>()
                .HasKey(x => new { x.PerformerId, x.SongId });

            ////Performer
            //builder.Entity<Performer>()
            //     .HasKey(p => p.Id);

            ////Producer
            //builder.Entity<Producer>()
            //     .HasKey(p => p.Id);

            ////Song
            //builder.Entity<Song>()
            //     .HasNoKey();

            ////Writer
            //builder.Entity<Writer>()
            //    .HasKey(w => w.Id);
        }
    }
}
