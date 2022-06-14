using kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolokwium.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {

        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");
            builder.HasKey(e => e.IdAlbum);
            builder.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
            builder.Property(e => e.PublishDate).IsRequired();

            builder.HasOne(e => e.MusicLabel)
                .WithMany(e => e.Albums)
                .HasForeignKey(e => e.IdMusicLabel)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new Album
            {
                IdAlbum = 1,
                AlbumName = "Que",
                PublishDate = new System.DateTime(2022, 1, 1),
                IdMusicLabel = 1
            });

        }
    }
}

