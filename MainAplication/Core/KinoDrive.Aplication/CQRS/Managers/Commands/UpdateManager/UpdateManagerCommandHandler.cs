using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.CQRS.BranchOffices.Queries;
using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Managers.Commands.UpdateManager
{
    public class UpdateManagerCommandHandler 
        :IRequestHandler<UpdateManagerCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public UpdateManagerCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateManagerCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == request.Id);

            if (user is null)
            {
                throw new NotFoundException("Менеджер не найден", request.Id);
            }

            var branchOffice = await _context.BranchOffices.FirstOrDefaultAsync(br => br.Id == request.BranchOfficeId);

            if (branchOffice is null)
            {
                throw new NotFoundException("Данный филиал не найден", request.BranchOfficeId);
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.NickName = request.NickName;
            user.BranchOfficeId = request.BranchOfficeId;



            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
