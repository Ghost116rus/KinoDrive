using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficeShedule
{
    public class GetBranchOfficeSheduleQuery :IRequest<BranchOfficeSheduleVm>
    {
        public int BranchOfficeId { get; set; }
    }
}
