using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.ActorCRUD.DeleteFilmActor
{
    public class DeleteFilmActorCommandHanlder : IRequestHandler<DeleteFilmActorCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public DeleteFilmActorCommandHanlder(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteFilmActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == request.Id);


            if (actor is null)
            {
                throw new NotFoundException($"Актер с id={request.Id} не был найден", request.Id);
            }

            _context.Actors.Remove(actor);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
