using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimeTableHard
{
    public class GetTimeTableHardQuery : IRequest<TableVM>
    {
        public int BranchOfficeId { get; set; }
    }
}
