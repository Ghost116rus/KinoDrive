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

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficesList
{
    public class GetBranchOfficesListQueryHandlier : 
        IRequestHandler<GetBranchOfficesListQuery, ListVM>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetBranchOfficesListQueryHandlier(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ListVM> Handle(GetBranchOfficesListQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.BranchOffices.ProjectTo<BranchOfficeVm>(_mapper.ConfigurationProvider).ToListAsync();

            return new ListVM { OfficeList = list };
        }
    }
}
