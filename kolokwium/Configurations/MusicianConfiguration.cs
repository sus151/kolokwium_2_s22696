using kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolokwium.Configurations
{
    public class MusicianConfiguration : IEntityTypeConfiguration<Musician>
    {

        public void Configure(EntityTypeBuilder<Musician> builder)
        {
            builder.ToTable("Musician");
            builder.HasKey(e => e.IdMusician);
            builder.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.NickName).HasMaxLength(20);

            builder.HasData(new Musician
            {
                IdMusician = 1,
                FirstName = "Jakub",
                LastName = "Jakubowski",
                NickName = "JJ"
            });

        }
    }
}

