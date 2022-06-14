using kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolokwium.Configurations
{
    public class MusicLabelConfiguration : IEntityTypeConfiguration<MusicLabel>
    {

        public void Configure(EntityTypeBuilder<MusicLabel> builder)
        {
            builder.ToTable("MusicLabel");
            builder.HasKey(e => e.IdMusicLabel);
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();


            builder.HasData(new MusicLabel
            {
                IdMusicLabel = 1,
                Name = "SBM"
            });

        }
    }
}
