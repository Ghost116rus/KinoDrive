using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Operator.Queries.GetOperatorList
{
    public class GetOperatorListQuery : IRequest<List<OperatorVm>>
    {

    }
}
