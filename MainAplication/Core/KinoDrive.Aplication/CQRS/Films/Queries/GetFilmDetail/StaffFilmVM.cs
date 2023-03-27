using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail
{
    public class StaffFilmVM : IMapWith<FilmDirector>, IMapWith<Actor>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FilmDirector, StaffFilmVM>()
                .ForMember(directorVm => directorVm.Id,
                opt => opt.MapFrom(director => director.Id))
                .ForMember(directorVm => directorVm.Name,
                opt => opt.MapFrom(director => director.Name));
            profile.CreateMap<Actor, StaffFilmVM>()
                .ForMember(actorVm => actorVm.Id,
                opt => opt.MapFrom(actor => actor.Id))
                .ForMember(directorVm => directorVm.Name,
                opt => opt.MapFrom(director => director.Name));
        }
    }
}
