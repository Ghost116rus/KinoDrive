using MediaCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaServer.DAL.EntityTypeConfiguration
{
    public class FilmImageMediaServerConfiguration : IEntityTypeConfiguration<FilmImage>
    {
        public void Configure(EntityTypeBuilder<FilmImage> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .HasOne(i => i.Film)
                .WithMany(f => f.Images)
                .HasForeignKey(f => f.FilmId);

            builder.Property(i => i.FileName).HasMaxLength(255);
            builder.Property(i => i.UrlForFile).HasMaxLength(500);
        }
    }
}
