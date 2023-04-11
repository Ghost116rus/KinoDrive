using MediaCore.Aplication.Interfaces;
using MediaCore.Domain;
using MediaServer.DAL.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaServer.DAL.Context
{
    public class MediaServerContext : DbContext, IMediaServerContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmImage> FilmImages { get; set; }

        public MediaServerContext(DbContextOptions<MediaServerContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FilmImageMediaServerConfiguration());
        }
    }

}
