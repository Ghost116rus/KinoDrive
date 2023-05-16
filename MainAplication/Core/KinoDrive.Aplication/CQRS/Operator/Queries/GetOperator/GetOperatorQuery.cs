using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Operator.Queries.GetOperator
{
    public class GetOperatorQuery : IRequest<OperatorVm>
    {
        public int Id { get; set; }
    }
}
