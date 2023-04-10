using MediaCore.Aplication.Interfaces;
using MediaCore.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnidecodeSharpFork;

namespace MediaCore.Aplication.Services
{
    public class FilmImageService : IFilmImageService
    {
        private readonly IMediaServerContext _context;

        private string _filePath;

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

        private async Task AddNewRecordFilmImage(int filmId, string fileName, string Url)
        {
            var record = await _context.FilmImages.FirstOrDefaultAsync(x => x.UrlForFile == Url);

            if (record != null) { record.FileName = fileName; record.UrlForFile = Url; }
            else
            {
                record = new FilmImage() { FileName = fileName, UrlForFile = Url, FilmId = filmId };
                await _context.FilmImages.AddAsync(record);
            }
        }

        public async Task<int> SavePoster(int filmId, IFormFile file, CancellationToken cancellationToken)
        {
            var film = await _context.Films.FirstOrDefaultAsync(x => x.Id == filmId);

            if (film == null) return -1;

            _filePath = "../../media/" + MakeDirPath(film.Name);

            if (!Directory.Exists(_filePath))
            {
                Directory.CreateDirectory(_filePath);
            }

            var extension = file.FileName.Split(".");
            var name = "poster." + extension[extension.Length - 1];

            string fullPath = $"{_filePath}/{name}";

            var inetAddress = fullPath.Substring(6);
            await AddNewRecordFilmImage(filmId, name, inetAddress);

            // сохраняем файл в папку 
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return 4;

        }

        public async Task<int> SaveImages(int filmId, List<IFormFile> files, CancellationToken cancellationToken)
        {

            var film = await _context.Films.FirstOrDefaultAsync(x => x.Id == filmId);

            if (film == null) return -1;

            _filePath = "../../media/" + MakeDirPath(film.Name);


            if (!Directory.Exists(_filePath))
            {
                Directory.CreateDirectory(_filePath);
            }

            foreach (var file in files)
            {
                // путь к папке uploads
                string fullPath = $"{_filePath}/{file.FileName}";
                var inetAddress = fullPath.Substring(6);
                await AddNewRecordFilmImage(filmId, file.FileName, inetAddress);

                // сохраняем файл в папку uploads
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);


            return 5;
        }
    }
}
