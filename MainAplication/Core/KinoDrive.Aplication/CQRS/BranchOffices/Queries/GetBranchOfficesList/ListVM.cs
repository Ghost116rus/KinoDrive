using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficesList
{
    public class BranchOfficeLookupForCity  : IMapWith<BranchOfficeVm>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public int StartWorkTime { get; set; }
        public int EndWorkTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BranchOfficeVm, BranchOfficeLookupForCity>();
        }
    }

    public class CityWTheatres
    {
        public string City { get; set; }
        public IList<BranchOfficeLookupForCity> Theatres { get; set; }
    }

    public class ListVM
    {
        public IList<CityWTheatres> OfficeList { get; set; }
    }
}
