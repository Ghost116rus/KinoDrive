using KinoDrive.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Persistance.EntityTypeConfiguration
{
    public class UserFilmRatingComfiguration : IEntityTypeConfiguration<UserFilmRating>
    {
        public void Configure(EntityTypeBuilder<UserFilmRating> builder)
        {
            builder.HasKey(k => new { k.UserId, k.FilmId });

            builder
                .HasOne(r => r.Film)
                .WithMany(f => f.UserFilmRating)
                .HasForeignKey(r => r.FilmId);

            builder
                .HasOne(r => r.User)
                .WithMany(u => u.UserFilmRating)
                .HasForeignKey(r => r.UserId);

            builder.Property(UFR => UFR.Value).HasColumnType("decimal(2,0)");
        }
    }
}
