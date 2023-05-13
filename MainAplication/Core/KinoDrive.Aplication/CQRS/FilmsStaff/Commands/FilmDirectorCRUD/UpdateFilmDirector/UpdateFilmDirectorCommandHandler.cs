using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.FilmDirectorCRUD.UpdateFilmDirector
{
    public class UpdateFilmDirectorCommandHandler : IRequestHandler<UpdateFilmDirectorCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public UpdateFilmDirectorCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateFilmDirectorCommand request, CancellationToken cancellationToken)
        {
            var filmDirector = await _context.FilmDirectors.FirstOrDefaultAsync(x => x.Id == request.filmDirectorId);

            if (filmDirector is null)
            {
                throw new NotFoundException($"Режиссер с заданным id={request.filmDirectorId} не найден", request.filmDirectorId);
            }

            filmDirector.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
