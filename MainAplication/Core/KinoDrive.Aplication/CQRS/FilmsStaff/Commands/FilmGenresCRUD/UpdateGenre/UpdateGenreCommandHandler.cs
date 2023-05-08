using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.FilmGenresCRUD.UpdateGenre
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public UpdateGenreCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (genre is null)
            {
                throw new NotFoundException($"Жанр с id={request.Id} не был найден", request.Id);
            }

            genre.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
