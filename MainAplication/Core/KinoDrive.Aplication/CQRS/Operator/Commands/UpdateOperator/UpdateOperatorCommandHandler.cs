using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Operator.Commands.UpdateOperator
{
    public class UpdateOperatorCommandHandler : IRequestHandler<UpdateOperatorCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public UpdateOperatorCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateOperatorCommand request, CancellationToken cancellationToken)
        {
            var operatoR = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.Role == "Operator");

            if (operatoR == null) throw new NotFoundException("Оператор не найден", request.Id);

            operatoR.FirstName = request.FirstName;
            operatoR.LastName = request.LastName;
            operatoR.NickName = request.NickName;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
