using kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolokwium.Configurations
{
    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {

        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("Track");
            builder.HasKey(e => e.IdTrack);
            builder.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
            builder.Property(e => e.Duration).IsRequired();


            builder.HasOne(e => e.Album)
                .WithMany(e => e.Tracks)
                .HasForeignKey(e => e.IdMusicAlbum)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new Track
            {
                IdTrack = 1,
                TrackName = "Ferrari",
                Duration = 5.55F,
                IdMusicAlbum = 1

            },
            new Track
            {
                IdTrack = 2,
                TrackName = "Berzek",
                Duration = 2.22F,
                IdMusicAlbum = 1
            });

        }
    }
}

