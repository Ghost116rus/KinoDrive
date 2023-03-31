using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficesListByCity
{
    public class BranchOfficeLookupDTO : IMapWith<BranchOffice>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BranchOffice, BranchOfficeLookupDTO>();
        }
    }
}
