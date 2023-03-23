using KinoDrive.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace KinoDrive.Persistance.EntityTypeConfiguration
{
    public class SeanceConfiguration : IEntityTypeConfiguration<Seance>
    {
        public void Configure(EntityTypeBuilder<Seance> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id);

            builder
                .HasOne(f => f.Film)
                .WithMany(s => s.Seances)
                .HasForeignKey(f => f.FilmId);

            builder
                .HasOne(h => h.CinemaHall)
                .WithMany(s => s.Seances)
                .HasForeignKey(f => f.CinemaHallId);
        }
    }
}
