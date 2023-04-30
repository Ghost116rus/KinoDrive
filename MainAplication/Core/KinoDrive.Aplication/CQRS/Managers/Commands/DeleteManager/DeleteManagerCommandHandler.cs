using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Managers.Commands.DeleteManager
{
    public class DeleteManagerCommandHandler
        : IRequestHandler<DeleteManagerCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public DeleteManagerCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteManagerCommand request, CancellationToken cancellationToken)
        {
            var manager = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.Role == "Manager");

            if (manager is null)
            {
                throw new NotFoundException("Пользователь не найден", request.Id);
            }

            _context.Users.Remove(manager);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
