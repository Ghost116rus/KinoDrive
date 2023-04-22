using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Reviews.Commands.ChangeRating
{
    public class ChangeRatingCommandHandler
        : IRequestHandler<ChangeRatingCommand>
    {
        private readonly IKinoDriveDbContext _kinoDriveDbContext;

        public ChangeRatingCommandHandler(IKinoDriveDbContext kinoDriveDbContext)
        {
            _kinoDriveDbContext = kinoDriveDbContext;
        }

        public async Task Handle(ChangeRatingCommand command, 
            CancellationToken cancellationToken)
        {
            var rating = await _kinoDriveDbContext.UserFilmRatings
                .FirstOrDefaultAsync(x => x.UserId == command.UserID && x.FilmId == command.FilmId);

            if (rating == null)
            {
                throw new NotFoundException("Rating", -1);
            }
            else if (rating.UserId != command.UserID) { throw new NotAccessException(); }

            rating.Value = command.NewValue;

            await _kinoDriveDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
