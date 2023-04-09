using MediaCore.Aplication.Interfaces;
using MediaCore.Domain;
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
        public DbSet<FilmImage> FilmImages { get; set; }

        public MediaServerContext(DbContextOptions<MediaServerContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }

}
