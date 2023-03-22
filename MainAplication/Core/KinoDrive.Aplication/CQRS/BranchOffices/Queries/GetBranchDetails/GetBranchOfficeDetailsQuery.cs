using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchDetails
{
    public class GetBranchOfficeDetailsQuery : IRequest<BranchOfficeVm>
    {
        public int Id { get; set; }
    }
}
