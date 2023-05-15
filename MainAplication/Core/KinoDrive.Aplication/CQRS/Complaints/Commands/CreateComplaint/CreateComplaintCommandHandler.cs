using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Complaints.Commands.CreateComplaint
{
    public class CreateComplaintCommandHandler : IRequestHandler<CreateComplaintCommand, int>
    {
        private readonly IKinoDriveDbContext _context;

        public CreateComplaintCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateComplaintCommand request, 
            CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == 1);

            if (request.BranchOfficeId is not null)
            {
                int br = (int)request.BranchOfficeId;
                var branchOffice = await _context.BranchOffices.FirstOrDefaultAsync(x => x.Id == br);

                if (branchOffice is null)
                {
                    throw new NotFoundException("Не был найден филиал для жалобы", request.BranchOfficeId);
                }

            }

            var complaint = new Complaint()
            {
                Description = request.Description,
                CreateDate = DateTime.Now,
                UserId = request.UserId,
                BranchOfficeId = request.BranchOfficeId
            };

            await _context.Complaints.AddAsync(complaint, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);


            return complaint.Id;
        }
    }
}
