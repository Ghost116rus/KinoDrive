using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Queries.GetGenresList
{
    public class GenreLookupDTO : IMapWith<Genre>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreLookupDTO>();
        }
    }

    public class GenreListVm
    {
        public IList<GenreLookupDTO> genres { get; set; }
    }
}
