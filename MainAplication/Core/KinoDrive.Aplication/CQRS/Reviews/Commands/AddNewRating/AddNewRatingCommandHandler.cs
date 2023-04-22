using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Reviews.Commands.AddNewRating
{
    public class AddNewRatingCommandHandler
        : IRequestHandler<AddNewRatingCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public AddNewRatingCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AddNewRatingCommand command, 
            CancellationToken cancellationToken)
        {
            var rating = new UserFilmRating
            {
                UserId = command.UserID,
                FilmId = command.UserID,
                Value = command.Value
            };

            await _context.UserFilmRatings.AddAsync(rating);

            await _context.SaveChangesAsync();
        }
    }
}
