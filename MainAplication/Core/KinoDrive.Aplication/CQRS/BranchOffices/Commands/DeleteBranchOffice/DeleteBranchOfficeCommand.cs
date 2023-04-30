using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Commands.DeleteBranchOffice
{
    public class DeleteBranchOfficeCommand :IRequest
    {
        public int BranchOfficeId { get; set; }
    }
}
