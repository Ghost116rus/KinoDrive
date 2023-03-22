using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.BranhcOffices.Commands.CreateBranchOffice
{
    public class CreateBranchOfficeCommandHandlier
                : IRequestHandler<CreateBranchOfficeCommand, Guid>
    {
        private readonly IKinoDriveDbContext _context;

        public CreateBranchOfficeCommandHandlier(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateBranchOfficeCommand request,
            CancellationToken cancellationToken)
        {
            var branch = new BranchOffice()
            {
                Id = Guid.NewGuid(),
                City = request.City,
                Adress = request.Adress,
                Description = request.Description
            };

            await _context.BranchOffices.AddAsync(branch, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return branch.Id;
        }
    }
}
