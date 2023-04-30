using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Commands.DeleteBranchOffice
{
    public class DeleteBranchOfficeCommandHandler :
        IRequestHandler<DeleteBranchOfficeCommand>
    {
        private readonly IKinoDriveDbContext _kinoDriveDbContext;

        public DeleteBranchOfficeCommandHandler(IKinoDriveDbContext kinoDriveDbContext)
        {
            _kinoDriveDbContext = kinoDriveDbContext;
        }

        public async Task Handle(DeleteBranchOfficeCommand request, CancellationToken cancellationToken)
        {
            var branchOffice = await _kinoDriveDbContext.BranchOffices
                .FirstOrDefaultAsync(x => x.Id == request.BranchOfficeId);

            if (branchOffice is null)
            {
                throw new NotFoundException("BranchOffice", request.BranchOfficeId);
            }

            // Меняем логику предложения ниже и можно делать более красиво
            _kinoDriveDbContext.BranchOffices.Remove(branchOffice);

            await _kinoDriveDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
