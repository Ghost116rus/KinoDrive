using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Operator.Commands.DeleteOperator
{
    public class DeleteOperatorCommandHanlder : IRequestHandler<DeleteOperatorCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public DeleteOperatorCommandHanlder(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteOperatorCommand request, CancellationToken cancellationToken)
        {
            var operatoR = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.OperatorId && x.Role == "Operator");

            if (operatoR == null) throw new NotFoundException("Оператор не найден", request.OperatorId);


            _context.Users.Remove(operatoR);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
