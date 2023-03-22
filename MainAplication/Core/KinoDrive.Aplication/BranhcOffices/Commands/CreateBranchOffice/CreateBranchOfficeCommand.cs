using KinoDrive.Aplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.BranhcOffices.Commands.CreateBranchOffice
{
    public class CreateBranchOfficeCommand : IRequest<Guid>
    {
        public string City { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }

    }
}
