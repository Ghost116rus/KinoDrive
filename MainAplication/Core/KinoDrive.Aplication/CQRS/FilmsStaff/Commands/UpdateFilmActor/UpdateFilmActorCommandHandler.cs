using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.UpdateFilmActor
{
    public class UpdateFilmActorCommandHandler : IRequestHandler<UpdateFilmActorCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public UpdateFilmActorCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateFilmActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == request.ActorId);

            if (actor is null)
            {
                throw new NotFoundException($"Актер с id={request.ActorId} не был найден", request.ActorId);
            }

            actor.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
