﻿using MediaCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace MediaCore.Aplication.Interfaces
{
    public interface IMediaServerContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmImage> FilmImages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
