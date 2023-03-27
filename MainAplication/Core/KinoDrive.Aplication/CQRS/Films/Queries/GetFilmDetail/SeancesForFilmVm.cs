using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail
{
    public class SeancesForFilmVm : IMapWith<Seance>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime SeanceStartTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seance, SeancesForFilmVm>()
                .ForMember(s => s.Name,
                opt => opt.MapFrom(s => s.CinemaHall.Name));
        }
    }
}