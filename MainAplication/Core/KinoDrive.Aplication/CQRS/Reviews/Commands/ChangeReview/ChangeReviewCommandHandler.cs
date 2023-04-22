using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Reviews.Commands.ChangeReview
{
    public class ChangeReviewCommandHandler 
        :IRequestHandler<ChangeReviewCommand>
    {
        private readonly IKinoDriveDbContext _kinoDriveDbContext;

        public ChangeReviewCommandHandler(IKinoDriveDbContext kinoDriveDbContext)
        {
            _kinoDriveDbContext = kinoDriveDbContext;
        }

        public async Task Handle(ChangeReviewCommand command, CancellationToken cancellationToken)
        {
            var review = await _kinoDriveDbContext.Reviews
                .FirstOrDefaultAsync(x=> x.UserId == command.UserId && x.FilmId == command.FilmId);

            if (review == null)
            {
                throw new NotFoundException("Review", -1);
            }
            else if (review.UserId != command.UserId) { throw new NotAccessException(); }

            review.Description = command.Description;

            await _kinoDriveDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
