using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.FilmDirectorCRUD.DeleteFilmDirector
{
    public class DeleteFilmDirectorCommandHandler : IRequestHandler<DeleteFilmDirectorCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public DeleteFilmDirectorCommandHandler (IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteFilmDirectorCommand request, CancellationToken cancellationToken)
        {
            var filmDirector = await _context.FilmDirectors.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (filmDirector is null)
            {
                throw new NotFoundException($"Режиссер с заданным id={request.Id} не найден", request.Id);
            }

            _context.FilmDirectors.Remove(filmDirector);

            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
