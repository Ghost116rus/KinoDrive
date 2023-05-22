using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimetableForWeek
{
    public class HallVM : IMapWith<CinemaHall>
    {
        public int Id { get; set; }

        public int HallNumber { get; set; }

        public IList<SeanceVM> Seances { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CinemaHall, HallVM>()
                .ForMember(h => h.HallNumber,
                    opt => opt.MapFrom(h => h.Name));
        }
    }
}
