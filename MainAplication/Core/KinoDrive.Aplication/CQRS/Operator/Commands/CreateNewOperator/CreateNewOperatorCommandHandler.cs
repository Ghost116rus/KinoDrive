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

namespace KinoDrive.Aplication.CQRS.Operator.Commands.CreateNewOperator
{
    public class CreateNewOperatorCommandHandler : IRequestHandler<CreateNewOperatorCommand, int>
    {
        private readonly IKinoDriveDbContext _context;

        public CreateNewOperatorCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateNewOperatorCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user is not null)
            {
                throw new RegisterException();
            }

            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                NickName = request.NickName,
                Role = request.Role
            };

            _context.Users.Add(newUser);

            await _context.SaveChangesAsync(cancellationToken);

            return newUser.Id;
        }
    }
}
