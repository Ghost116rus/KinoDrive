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

            if (command.FirstName is not null)  { user.FirstName = command.FirstName; }
            if (command.LastName is not null)   { user.LastName = command.LastName; }
            if (command.NickName is not null)   { user.NickName = command.NickName; }
            if (command.Email is not null)      { user.Email = command.Email; }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
