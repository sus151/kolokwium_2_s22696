using kolokwium.Configurations;
using kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.DataAccess
{
    public class DBContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicianTrack> MusicianTracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Track> Tracks { get; set; }



        public DBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicianConfiguration());
            modelBuilder.ApplyConfiguration(new MusicianTrackConfiguration());
            modelBuilder.ApplyConfiguration(new TrackConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
            modelBuilder.ApplyConfiguration(new MusicLabelConfiguration());
        }
    }

    
    
    
}
