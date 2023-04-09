using MediaCore.Aplication.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCore.Aplication.Services
{
    public class FilmImageService : IFilmImageService
    {
        private readonly IMediaServerContext _context;

        public Task<int> SaveImages(int filmId, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }
    }
}
