using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KinoDrive.Aplication.CQRS.Films.Commands.UpdateFilm
{
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand>
    {

        private readonly IKinopoiskAPI _kinopoiskAPI;
        private readonly IKinoDriveDbContext _context;

        public UpdateFilmCommandHandler(IKinopoiskAPI kinopoiskAPI, IKinoDriveDbContext context)
        {
            _kinopoiskAPI = kinopoiskAPI;
            _context = context;
        }

        private async void CheckGenres(Film film, UpdateFilmCommand request)
        {
            if (request.Genres is null)
            {
                throw new BadDataException("Нельзя создать фильм без жанров");
            }

            List<Genre> genres;

            if (film.Genres is null)
            {
                genres = new List<Genre>();
                foreach (var genreId in request.Genres)
                {
                    var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == genreId);
                    if (genre is not null)
                    {
                        genres.Add(genre);
                    }

                }
            }
            else
            {
                genres = film.Genres.ToList();

                foreach (var genre in film.Genres)
                {
                    var genreFromFront = request.Genres.FirstOrDefault(x => x == genre.Id, -1);

                    if (genreFromFront == -1)
                    {
                        genres.Remove(genre);
                    }
                    else
                    {
                        request.Genres.Remove(genreFromFront);
                    }
                }

                foreach (var genreId in request.Genres)
                {
                    var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == genreId);
                    if (genre is not null)
                    {
                        genres.Add(genre);
                    }

                }
            }

            film.Genres = genres;
        }

        private async void CheckActors(Film film, UpdateFilmCommand request)
        {
            if (request.ActorsId is null)
            {
                return;
            }

            List<Actor>? actors;

            if (film.Actors is null)
            {
                actors = new List<Actor>();
                foreach (var actorId in request.ActorsId)
                {
                    var actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == actorId);
                    if (actor is not null)
                    {
                        actors.Add(actor);
                    }
                }                
            }
            else
            {
                actors = film.Actors.ToList();

                foreach (var actor in film.Actors)
                {
                    var actorFromFront = request.ActorsId.FirstOrDefault(x => x == actor.Id, -1);

                    if (actorFromFront == -1)
                    {
                        actors.Remove(actor);
                    }
                    else
                    {
                        request.ActorsId.Remove(actorFromFront);
                    }
                }

                foreach (var actorId in request.ActorsId)
                {
                    var actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == actorId);
                    if (actor is not null)
                    {
                        actors.Add(actor);
                    }

                }
            }
            film.Actors = actors;
        }

        private async void CheckFilmDirectors(Film film, UpdateFilmCommand request)
        {
            if (request.FilmDirectorsId is null)
            {
                return;
            }

            List<FilmDirector>? filmDirectors;

            if (film.FilmDirectors is null)
            {
                filmDirectors = new List<FilmDirector>();
                foreach (var filmDirectorId in request.FilmDirectorsId)
                {
                    var filmDirector = await _context.FilmDirectors.FirstOrDefaultAsync(x => x.Id == filmDirectorId);
                    if (filmDirector is not null)
                    {
                        filmDirectors.Add(filmDirector);
                    }
                }
            }
            else
            {
                filmDirectors = film.FilmDirectors.ToList();

                foreach (var filmDirector in film.FilmDirectors)
                {
                    var filmDirectorFromFront = request.FilmDirectorsId.FirstOrDefault(x => x == filmDirector.Id, -1);

                    if (filmDirectorFromFront == -1)
                    {
                        filmDirectors.Remove(filmDirector);
                    }
                    else
                    {
                        request.FilmDirectorsId.Remove(filmDirectorFromFront);
                    }
                }

                foreach (var filmDirectorId in request.FilmDirectorsId)
                {
                    var filmDirector = await _context.FilmDirectors.FirstOrDefaultAsync(x => x.Id == filmDirectorId);
                    if (filmDirector is not null)
                    {
                        filmDirectors.Add(filmDirector);
                    }

                }
            }
            film.FilmDirectors = filmDirectors;
        }

        public async Task Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
        {
            var film = await _context.Films
                .Include(x => x.Genres)
                .Include(x => x.Actors)
                .Include(x => x.FilmDirectors)              
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (film is null)
            {
                throw new NotFoundException($"Фильм с id={request.Id} не был найден", request.Id);
            }


            film.Name = request.Name;
            film.Description = request.Description;
            film.ReleaseYear = request.ReleaseYear;
            film.Length = request.Length;
            film.isActive = request.isActive;

            film.AgeRestriction = request.AgeRestriction;
            film.UrlForTrailer = request.UrlForTrailer;
            film.UrlForKinopoisk = request.UrlForKinopoisk;


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

            CheckGenres(film, request);
            CheckActors(film, request);
            CheckFilmDirectors(film, request);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
