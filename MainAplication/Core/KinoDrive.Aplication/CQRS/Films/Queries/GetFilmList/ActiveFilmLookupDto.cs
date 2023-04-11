using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmList
{
    public class ActiveFilmLookupDto : IMapWith<Film>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float Rating { get; set; }
        public float RatingOnKinopoisk { get; set; }
        public int RatingOnImdb { get; set; }
        public IList<GenreVm> Genres { get; set; }
        public string Poster { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Film, ActiveFilmLookupDto>();
        }
    }
}
