using KinoDrive.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Persistance.EntityTypeConfiguration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id);

            builder
                .HasOne(s => s.Seance)
                .WithMany(b => b.Bookings)
                .HasForeignKey(f => f.SeanceId);

            builder
                .HasOne(u => u.User)
                .WithMany(b => b.Bookings)
                .HasForeignKey(f => f.UserId);
        }
    }
}
