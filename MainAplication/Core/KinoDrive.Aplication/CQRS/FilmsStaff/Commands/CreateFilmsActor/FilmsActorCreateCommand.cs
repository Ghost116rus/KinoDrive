using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.CreateFilmsActor
{
    public class FilmsActorCreateCommand : IRequest<int>
    {
        public string Name {get; set;}
    }
}
