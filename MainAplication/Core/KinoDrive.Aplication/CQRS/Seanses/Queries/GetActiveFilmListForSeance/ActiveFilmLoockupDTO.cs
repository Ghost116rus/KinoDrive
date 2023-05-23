using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Aplication.CQRS.Films.Queries;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetActiveFilmListForSeance
{
    public class ActiveFilmLoockupDTO : IMapWith<Film>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Film, ActiveFilmLoockupDTO>()
                .ForMember(f => f.Length,
                    opt => opt.MapFrom(f => (int)Math.Ceiling((double)(f.Length) / 5) * 5));
        }
    }
}
