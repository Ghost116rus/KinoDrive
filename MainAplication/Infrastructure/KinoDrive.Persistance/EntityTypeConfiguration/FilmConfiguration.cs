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
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);

            builder.Property(film => film.Name).HasMaxLength(500);
            builder.Property(film => film.Description).HasMaxLength(2000);
            builder.HasCheckConstraint("ReleaseYear", "ReleaseYear LIKE '[1,2][0,8,9][0-9][0-9]'");
        }
    }
}
