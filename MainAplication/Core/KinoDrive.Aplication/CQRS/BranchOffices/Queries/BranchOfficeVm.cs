using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;


namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries
{
    public class BranchOfficeVm : IMapWith<BranchOffice>
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BranchOffice, BranchOfficeVm>();
        }
    }
}
