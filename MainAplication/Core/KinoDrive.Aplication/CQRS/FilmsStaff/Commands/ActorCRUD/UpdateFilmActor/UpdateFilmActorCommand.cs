using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.ActorCRUD.UpdateFilmActor
{
    public class UpdateFilmActorCommand : IRequest
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
    }
}
