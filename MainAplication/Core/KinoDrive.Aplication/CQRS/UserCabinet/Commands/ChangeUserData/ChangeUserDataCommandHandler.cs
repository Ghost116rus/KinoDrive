using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.UserCabinet.Commands.ChangeUserData
{
    public class ChangeUserDataCommandHandler
        : IRequestHandler<ChangeUserDataCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public ChangeUserDataCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ChangeUserDataCommand command,
            CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == command.UserId);

            if (user == null) throw new NotFoundException("User", -1);

            user.FirstName = command.FirstName; 
            user.LastName = command.LastName; 
            user.NickName = command.NickName; 
            user.Email = command.Email; 

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
