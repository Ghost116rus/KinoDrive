using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Operator.Queries.GetOperatorList
{
    public class GetOperatorListQueryHandler : IRequestHandler<GetOperatorListQuery, List<OperatorVm>>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetOperatorListQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OperatorVm>> Handle(GetOperatorListQuery request, CancellationToken cancellationToken)
        {
            var operatorList = await _context.Users
                .Where(x => x.Role == "Operator")
                .ProjectTo<OperatorVm>(_mapper.ConfigurationProvider).ToListAsync();

            return operatorList;
        }
    }
}
