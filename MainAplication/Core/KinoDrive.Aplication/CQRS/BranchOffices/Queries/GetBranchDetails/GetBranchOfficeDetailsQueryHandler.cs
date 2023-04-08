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

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchDetails
{
    public class GetBranchOfficeDetailsQueryHandler
        : IRequestHandler<GetBranchOfficeDetailsQuery, BranchOfficeVm>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetBranchOfficeDetailsQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BranchOfficeVm> Handle(GetBranchOfficeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.BranchOffices
                .FirstOrDefaultAsync(office => office.Id == request.Id, cancellationToken);

            if (entity == null) throw new NotFoundException(nameof(BranchOfficeVm), request.Id);


            return _mapper.Map<BranchOfficeVm>(entity);
        }
    }
}
