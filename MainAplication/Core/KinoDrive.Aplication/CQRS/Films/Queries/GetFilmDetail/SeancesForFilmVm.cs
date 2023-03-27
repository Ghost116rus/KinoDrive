using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail
{
    public class SeancesForFilmVm : IMapWith<Seance>
    {
        public int Id { get; set; }
        public string BranchOfficeName { get; set; }
        public string CinemaHallName { get; set; }
        public string Type { get; set; }
        public DateTime SeanceStartTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seance, SeancesForFilmVm>()
                .ForMember(s => s.BranchOfficeName,
                opt => opt.MapFrom(s => s.CinemaHall.Office.Adress))
                .ForMember(s => s.CinemaHallName,
                opt => opt.MapFrom(s => s.CinemaHall.Name));
        }
    }
}