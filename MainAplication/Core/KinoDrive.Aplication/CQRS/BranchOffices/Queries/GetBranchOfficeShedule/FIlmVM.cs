using AutoMapper;
using KinoDrive.Aplication.Common.LocalHostUrls;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Aplication.CQRS.Films.Queries.GetFilmList;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficeShedule
{
    public class FIlmVM : IMapWith<Film>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AgeRestriction { get; set; }
        public string Poster { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Film, FIlmVM>()
                .ForMember(x => x.Poster,
                opt => opt.MapFrom(p => p.UrlForPoster == null ? null : LocalHostUrlForMedia.Url + p.UrlForPoster));
        }
    }
}
