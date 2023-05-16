using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Operator.Commands.UpdateOperator
{
    public class UpdateOperatorCommand : IRequest
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NickName { get; set; }
    }
}
