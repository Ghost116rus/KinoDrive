using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.ActorCRUD.CreateFilmsActor
{
    public class FilmsActorCreateCommandHandler : IRequestHandler<FilmsActorCreateCommand, int>
    {
        private readonly IKinoDriveDbContext _context;

        public FilmsActorCreateCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(FilmsActorCreateCommand request, CancellationToken cancellationToken)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.Name == request.Name);

            if (actor is not null)
            {
                return actor.Id;
            }

            actor = new Actor() { Name = request.Name };

            await _context.Actors.AddAsync(actor);

            await _context.SaveChangesAsync(cancellationToken);

            return actor.Id;
        }
    }
}
