using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.UserCabinet.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler
        : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IKinoDriveDbContext _kinoDriveDbContext;

        public ChangePasswordCommandHandler(IKinoDriveDbContext kinoDriveDbContext)
        {
            _kinoDriveDbContext = kinoDriveDbContext;
        }

        public async Task Handle(ChangePasswordCommand command,
            CancellationToken cancellationToken)
        {
            var user = await _kinoDriveDbContext.Users.FirstOrDefaultAsync(u => u.Id == command.UserId);

            if (user == null)
            {
                throw new NotFoundException("User", -1);
            }

            if (user.Password != command.OldPassword)
            {
                throw new BadDataException("oldPassword");   
            }

            user.Password = command.NewPassword;
            await _kinoDriveDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
