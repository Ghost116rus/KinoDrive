using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Queries.GetFilmDirectorsList
{
    public class FilmDirectorsLookupDTO : IMapWith<FilmDirector>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FilmDirector, FilmDirectorsLookupDTO>();  
        }
    }

    public class FilmDirectorsListVm
    {
        public IList<FilmDirectorsLookupDTO> FilmDirectorList { get; set; }
    }
}
