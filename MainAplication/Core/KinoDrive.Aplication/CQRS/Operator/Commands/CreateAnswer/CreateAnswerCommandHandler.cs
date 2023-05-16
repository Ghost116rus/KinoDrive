using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Operator.Commands.CreateAnswer
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand>
    {
        private readonly IKinoDriveDbContext _context;
        
        public CreateAnswerCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            var complaint = await _context.Complaints.FirstOrDefaultAsync(x => x.Id == request.ComplaintId);

            if (complaint is null)
            {
                throw new NotFoundException("Жалоба не была найдена", request.ComplaintId);
            }

            complaint.Answer = request.Text;
            complaint.AnswerDate = DateTime.Now;


            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
