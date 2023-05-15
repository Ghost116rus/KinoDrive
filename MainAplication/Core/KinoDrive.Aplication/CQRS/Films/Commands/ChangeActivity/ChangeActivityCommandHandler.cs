using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Commands.ChangeActivity
{
    public class ChangeActivityCommandHandler : IRequestHandler<ChangeActivityCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public ChangeActivityCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ChangeActivityCommand request, CancellationToken cancellationToken)
        {
            var film = await _context.Films.FirstOrDefaultAsync(x => x.Id == request.FilmId);

            if (film is null)
            {
                throw new NotFoundException($"Фильм с id={request.FilmId} не найден", request.FilmId);
            }

            film.isActive = request.IsActive;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
