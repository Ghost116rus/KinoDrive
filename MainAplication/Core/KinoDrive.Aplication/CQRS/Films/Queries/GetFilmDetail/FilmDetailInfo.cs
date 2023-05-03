using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail
{
    public class FilmDetailInfo : IMapWith<Film>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AgeRestriction { get; set; }
        public int ReleaseYear { get; set; }
        public int Length { get; set; }

        public float Rating { get; set; }
        public float? RatingOnKinopoisk { get; set; }
        public float? RatingOnImdb { get; set; }

        public string UrlForTrailer { get; set; }

        public IList<StaffFilmVM>? FilmDirectors { get; set; }
        public IList<StaffFilmVM>? Actors { get; set; }
        public IList<GenreVm>? Genres { get; set; }

        public string Poster { get; set; }
        public IList<string> ImagesUrls { get; set; } = new List<string>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Film, FilmDetailInfo>();
        }
    }
}
