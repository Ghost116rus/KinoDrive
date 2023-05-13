using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.FilmGenresCRUD.DeleteGenre
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public DeleteGenreCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (genre is null)
            {
                throw new NotFoundException($"Жанр с id={request.Id} не найден", request.Id);
            }

            _context.Genres.Remove(genre);

            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
