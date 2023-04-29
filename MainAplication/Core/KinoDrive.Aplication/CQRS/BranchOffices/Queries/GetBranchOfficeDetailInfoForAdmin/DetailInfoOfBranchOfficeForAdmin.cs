using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficeDetailInfoForAdmin
{
    public class DetailInfoOfBranchOfficeForAdmin : IMapWith<BranchOffice>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Description { get; set; }

        public int StartWorkTime { get; set; }
        public int EndWorkTime { get; set; }

        public string City { get; set; }
        public string Adress { get; set; }

        public float Longitude { get; set; }
        public float Latitude { get; set; }

        public IEnumerable<CinemaHallLookupDTO> CinemaHallsList { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BranchOffice, DetailInfoOfBranchOfficeForAdmin>();
        }
    }
}
