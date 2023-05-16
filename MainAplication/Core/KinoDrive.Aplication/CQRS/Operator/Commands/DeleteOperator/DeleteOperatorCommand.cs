using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Operator.Commands.DeleteOperator
{
    public class DeleteOperatorCommand : IRequest 
    {
        public int OperatorId { get; set; }
    }
}
