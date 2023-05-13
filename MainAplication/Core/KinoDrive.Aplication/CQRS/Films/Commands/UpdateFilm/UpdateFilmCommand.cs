using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Commands.UpdateFilm
{
    public class UpdateFilmCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int Length { get; set; }
        public bool isActive { get; set; }

        public int AgeRestriction { get; set; }
        public string? UrlForTrailer { get; set; }
        public string? UrlForKinopoisk { get; set; }

        public IList<int> Genres { get; set; }
        public IList<int>? ActorsId { get; set; }
        public IList<int>? FilmDirectorsId { get; set; }
    }
}
