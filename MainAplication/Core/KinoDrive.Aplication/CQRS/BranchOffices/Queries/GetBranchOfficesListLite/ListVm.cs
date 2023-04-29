using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficesListLite
{
    public class BranchOfficeLookup: IMapWith<BranchOfficeVm>
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BranchOffice, BranchOfficeLookup>();
        }
    }

    public class ListVm
    {
        public IList<BranchOfficeLookup> OfficeList { get; set; }
    }
}
