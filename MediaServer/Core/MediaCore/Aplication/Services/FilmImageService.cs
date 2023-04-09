using MediaCore.Aplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidecodeSharpFork;

namespace MediaCore.Aplication.Services
{
    public class FilmImageService : IFilmImageService
    {
        private readonly IMediaServerContext _context;

        public FilmImageService(IMediaServerContext context)
        {
            _context = context;
        }
        private string MakeDirPath(string filmName)
        {
            filmName = filmName.Unidecode();          

            string path = "";

            foreach (var part in filmName.Split())
            {
                if (part == ""){ continue; }
                var firstSymbol = Char.ToUpper(part[0]);
                path += firstSymbol + part.Substring(1);
            }

            return path;
        }

        public async Task<int> SaveImages(int filmId, List<IFormFile> files)
        {

            var film = await _context.Films.FirstOrDefaultAsync(x => x.Id == filmId);

            if (film == null) return -1;

            Console.WriteLine(MakeDirPath(film.Name));

            Console.WriteLine("Hello world");

            return 5;
        }
    }
}
