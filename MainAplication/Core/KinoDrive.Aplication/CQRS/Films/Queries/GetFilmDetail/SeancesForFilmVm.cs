using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail
{
    public class SeancesForFilmVm : IMapWith<SeancesForFilmList>
    {
        public int Id { get; set; }
        public string CinemaHallName { get; set; }
        public string Type { get; set; }
        public TimeSpan SeanceStartTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SeancesForFilmList, SeancesForFilmVm>()
                .ForMember(s => s.SeanceStartTime,
                opt => opt.MapFrom(s => s.SeanceStartTime.TimeOfDay));
        }
    }
}