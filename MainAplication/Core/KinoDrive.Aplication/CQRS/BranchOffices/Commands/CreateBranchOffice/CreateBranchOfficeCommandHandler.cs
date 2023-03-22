using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;


namespace KinoDrive.Aplication.CQRS.BranchOffices.Commands.CreateBranchOffice
{
    public class CreateBranchOfficeCommandHandlier
                : IRequestHandler<CreateBranchOfficeCommand, int>
    {
        private readonly IKinoDriveDbContext _context;

        public CreateBranchOfficeCommandHandlier(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBranchOfficeCommand request,
            CancellationToken cancellationToken)
        {
            var branch = new BranchOffice()
            {
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
