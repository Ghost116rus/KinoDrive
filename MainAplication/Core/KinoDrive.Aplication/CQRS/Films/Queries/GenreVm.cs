using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Queries
{
    public class GenreVm : IMapWith<Genre>
    {
        public string Description { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<Genre, GenreVm>();
    }
}
