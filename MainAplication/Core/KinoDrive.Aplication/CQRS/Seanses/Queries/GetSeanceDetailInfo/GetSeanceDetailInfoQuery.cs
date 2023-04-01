using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetSeanceDetailInfo
{
    public class GetSeanceDetailInfoQuery : IRequest<SeanceDetailInfoVm>
    {
        public int SeanceId { get; set; }
    }
}
