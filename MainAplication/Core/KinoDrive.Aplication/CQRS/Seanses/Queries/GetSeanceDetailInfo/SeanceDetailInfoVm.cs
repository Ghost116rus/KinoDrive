using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetSeanceDetailInfo
{
    public class SeanceDetailInfoVm : IMapWith<Seance>
    {
        public string CinemaHallName { get; set; }
        public string FilmName { get; set; }

        public int NumOfRow { get; set; }
        public int NumOfPlacesInRow { get; set; }

        public IList<BookingPlaceVM> Places { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seance, SeanceDetailInfoVm>()
                .ForMember(s => s.CinemaHallName,
                    opt => opt.MapFrom(cH => cH.CinemaHall.Name))                
                .ForMember(s => s.NumOfRow,
                    opt => opt.MapFrom(cH => cH.CinemaHall.NumOfRow))                
                .ForMember(s => s.NumOfPlacesInRow,
                    opt => opt.MapFrom(cH => cH.CinemaHall.NumOfPlacesInRow))
                .ForMember(s => s.FilmName,
                    opt => opt.MapFrom(f => f.Film.Name));
        }

    }
}
