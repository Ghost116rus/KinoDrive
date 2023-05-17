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
    public class FilmVM : IMapWith<Film>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Film, FilmVM>()
                .ForMember(f => f.Duration,
                    opt => opt.MapFrom(f => f.Length));
        }

    }
}
