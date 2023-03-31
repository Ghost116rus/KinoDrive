using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficesListByCity
{
    public class GetBranchOfficesListByCityQuery : IRequest<BranchOfficeListVm>
    {
        public string City { get; set; }    
    }
}
