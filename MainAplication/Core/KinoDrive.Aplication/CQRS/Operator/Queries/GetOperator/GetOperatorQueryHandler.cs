using AutoMapper;
using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Operator.Queries.GetOperator
{
    public class GetOperatorQueryHandler : IRequestHandler<GetOperatorQuery, OperatorVm>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetOperatorQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OperatorVm> Handle(GetOperatorQuery request, CancellationToken cancellationToken)
        {
            var operatoR = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.Role == "Operator");

            if (operatoR == null) throw new NotFoundException("Оператор не найден", request.Id);

            return _mapper.Map<OperatorVm>(operatoR);
        }
    }
}
