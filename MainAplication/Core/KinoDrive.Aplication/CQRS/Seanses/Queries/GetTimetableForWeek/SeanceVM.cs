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
    public class SeanceVM : IMapWith<Seance>
    {
        public int Id { get; set; }

        public int Cost { get; set; } = -1;

        public FilmVM Film { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seance, SeanceVM>()
                .ForMember(x => x.Cost,
                opt => opt.MapFrom(s => s.BasicCost));
        }

    }
}
