using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail
{
    public class SeancesForFilmList : IMapWith<Seance>
    {
        public int Id { get; set; }
        public string BranchOfficeName { get; set; }
        public string Type { get; set; }
        public int BasicCost { get; set; }
        public DateTime SeanceStartTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seance, SeancesForFilmList>()
                .ForMember(s => s.BranchOfficeName,
                opt => opt.MapFrom(s => s.CinemaHall.Office.Name));
        }
    }
}
