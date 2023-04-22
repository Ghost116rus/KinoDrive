using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Reviews.Commands
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
            var review = new Review
            {
                UserId = command.UserId,
                FilmId = command.FilmId,
                Description = command.Description
            };

            await _context.Reviews.AddAsync(review);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
