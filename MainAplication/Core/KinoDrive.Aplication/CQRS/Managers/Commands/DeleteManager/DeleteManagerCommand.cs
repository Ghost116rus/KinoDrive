using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Managers.Commands.DeleteManager
{
    public class DeleteManagerCommand : IRequest
    {
        public int Id { get; set; } 
    }
}
