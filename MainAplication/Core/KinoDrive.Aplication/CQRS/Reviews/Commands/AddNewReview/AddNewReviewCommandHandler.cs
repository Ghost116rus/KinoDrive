using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Reviews.Commands.AddNewReview
{
    public class AddNewReviewCommandHandler
        : IRequestHandler<AddNewReviewCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public AddNewReviewCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(AddNewReviewCommand command,
            CancellationToken cancellationToken)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(x => x.UserId == command.UserId && x.FilmId == command.FilmId);

            if (review is not null)
            {
                review.Value = command.Value;
            }
            else
            {
                review = new Review
                {
                    UserId = command.UserId,
                    FilmId = command.FilmId,
                    Value = command.Value,
                };

                await _context.Reviews.AddAsync(review);
            }

            if (command.Description is not null)
            {
                review.Description = command.Description;
            }

            review.ChangeDate = DateTime.Now;


            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
