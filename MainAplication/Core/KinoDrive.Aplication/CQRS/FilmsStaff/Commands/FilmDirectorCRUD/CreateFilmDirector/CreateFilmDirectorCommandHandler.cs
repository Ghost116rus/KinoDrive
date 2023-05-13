using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Commands.FilmDirectorCRUD.CreateFilmDirector
{
    public class CreateFilmDirectorCommandHandler : IRequestHandler<CreateFilmDirectorCommand, int>
    {
        private readonly IKinoDriveDbContext _context;

        public CreateFilmDirectorCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateFilmDirectorCommand request, CancellationToken cancellationToken)
        {
            var filmDirector = await _context.FilmDirectors.FirstOrDefaultAsync(x => x.Name == request.Name);

            if (filmDirector is not null)
            {
                return filmDirector.Id;
            }

            filmDirector = new FilmDirector() { Name = request.Name };

            await _context.FilmDirectors.AddAsync(filmDirector);

            await _context.SaveChangesAsync(cancellationToken);

            return filmDirector.Id;
        }
    }
}
