using kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolokwium.Configurations
{
    public class MusicianTrackConfiguration : IEntityTypeConfiguration<MusicianTrack>
    {

        public void Configure(EntityTypeBuilder<MusicianTrack> builder)
        {
            builder.ToTable("Musician_Track");
            builder.HasKey(e => new
            {
                e.IdTrack,
                e.IdMusician
            });



            builder.HasOne(e => e.Musician)
                .WithMany(e => e.MusicianTracks)
                .HasForeignKey(e => e.IdMusician)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Track)
                .WithMany(e => e.MusicianTracks)
                .HasForeignKey(e => e.IdTrack)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new MusicianTrack
            {
                IdTrack = 1,
                IdMusician = 1
            });

        }
    }
}
