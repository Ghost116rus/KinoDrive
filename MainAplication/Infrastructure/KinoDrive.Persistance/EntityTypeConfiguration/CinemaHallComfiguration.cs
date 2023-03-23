using KinoDrive.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;


namespace KinoDrive.Persistance.EntityTypeConfiguration
{
    public class CinemaHallComfiguration : IEntityTypeConfiguration<CinemaHall>
    {
        public void Configure(EntityTypeBuilder<CinemaHall> builder)
        {
            builder
                .HasOne(office => office.Office)
                .WithMany(cinema => cinema.CinemaHalls)
                .HasForeignKey(f => f.OfficeId);
        }
    }
}
