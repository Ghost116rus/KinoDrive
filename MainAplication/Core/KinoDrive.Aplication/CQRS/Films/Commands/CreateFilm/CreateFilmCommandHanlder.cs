using KinoDrive.Aplication.Common.AnotherAPI;
using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KinoDrive.Aplication.CQRS.Films.Commands.CreateFilm
{
    public class CreateFilmCommandHanlder : IRequestHandler<CreateFilmCommand, int> 
    {
        private readonly IKinopoiskAPI _kinopoiskAPI;
        private readonly IKinoDriveDbContext _context;

        public CreateFilmCommandHanlder(IKinopoiskAPI kinopoiskAPI, IKinoDriveDbContext context)
        {
            _kinopoiskAPI = kinopoiskAPI;
            _context = context;
        }

        // На доработку
        public async Task<int> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {

            var film = new Film
            {
                Name = request.Name,
                Description = request.Description,
                ReleaseYear = request.ReleaseYear,
                Length = request.Length,
                isActive = true,
                AgeRestriction = request.AgeRestriction,
                UrlForTrailer = request.UrlForTrailer,
                UrlForKinopoisk = request.UrlForKinopoisk
            };

            if (request.UrlForKinopoisk is not null)
            {
                var ratings = _kinopoiskAPI.GetRatings(request.UrlForKinopoisk);

                if (ratings is not null)
                {
                    if (ratings.ContainsKey("kp_rating"))
                    { film.RatingOnKinopoisk = ratings["kp_rating"]; }

                    if (ratings.ContainsKey("imdb_rating"))
                    { film.RatingOnImdb = ratings["imdb_rating"]; }
                }
            }

            var genres = new List<Genre>();
            foreach (var genreId in request.Genres)
            {
                var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == genreId);
                if (genre is not null)
                {
                    genres.Add(genre);
                }

            }
            film.Genres = genres;



            if (request.ActorsId is not null)
            {
                var actors = new List<Actor>();
                foreach (var actorId in request.ActorsId)
                {
                    var actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == actorId);
                    if (actor is not null)
                    {
                        actors.Add(actor);
                    }
                }
                film.Actors = actors;
            }

            if (request.FilmDirectorsId is not null)
            {
                var filmDirectors = new List<FilmDirector>();
                foreach (var filmDirectorId in request.FilmDirectorsId)
                {
                    var filmDirector = await _context.FilmDirectors.FirstOrDefaultAsync(x => x.Id == filmDirectorId);
                    if (filmDirector is not null)
                    {
                        filmDirectors.Add(filmDirector);
                    }
                }
                film.FilmDirectors = filmDirectors;
            }

            await _context.Films.AddAsync(film, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return film.Id;
        }
    }
}
