using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficesListLite
{
    public class GetBranchOfficesListLiteQueryHandler
        : IRequestHandler<GetBranchOfficesListLiteQuery, ListVm>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetBranchOfficesListLiteQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ListVm> Handle(GetBranchOfficesListLiteQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.BranchOffices.ProjectTo<BranchOfficeLookup>(_mapper.ConfigurationProvider).ToListAsync();

            if (list.Count == 0)
            {
                throw new NotFoundException("BranchOfficesListLite", -1);
            }

            return new ListVm { OfficeList = list};
        }
    }
}
