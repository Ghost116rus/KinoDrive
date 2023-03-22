using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Aplication.CQRS.BranchOffices.Commands.CreateBranchOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Models
{
    public class CreateBranchOfficeDTO : IMapWith<CreateBranchOfficeCommand>
    {
        public string City { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBranchOfficeDTO, CreateBranchOfficeCommand>();
        }

    }
}
