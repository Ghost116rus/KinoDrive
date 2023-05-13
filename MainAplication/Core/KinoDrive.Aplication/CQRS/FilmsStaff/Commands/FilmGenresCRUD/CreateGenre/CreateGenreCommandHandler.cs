using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.FilmGenresCRUD.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
    {
        private readonly IKinoDriveDbContext _context;

        public CreateGenreCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Description == request.Name);

            if (genre is not null)
            {
                return genre.Id;
            }

            genre = new Genre() { Description = request.Name };

            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync(cancellationToken);

            return genre.Id;
        }

    }
}
