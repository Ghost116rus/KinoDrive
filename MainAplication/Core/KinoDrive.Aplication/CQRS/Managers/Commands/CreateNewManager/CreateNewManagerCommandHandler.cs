using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KinoDrive.Aplication.CQRS.Managers.Commands.CreateNewManager
{
    public class CreateNewManagerCommandHandler
        : IRequestHandler<CreateNewManagerCommand, int>
    {
        private readonly IKinoDriveDbContext _context;

        public CreateNewManagerCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateNewManagerCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == request.Email);

            if (user is not null)
            {
                throw new RegisterException();
            }

            var branchOffice = await _context.BranchOffices.FirstOrDefaultAsync(br => br.Id == request.BranchOfficeId);

            if (branchOffice is null)
            {
                throw new NotFoundException("Данный филиал не найден", request.BranchOfficeId);
            }

            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                NickName = request.NickName,
                Role = request.Role,
                BranchOfficeId = request.BranchOfficeId
            };

            _context.Users.Add(newUser);

            await _context.SaveChangesAsync(cancellationToken);

            return newUser.Id;
        }
    }
}
