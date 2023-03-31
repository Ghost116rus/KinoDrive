using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficesListByCity
{
    public class GetBranchOfficesListByCityQueryHandler
        : IRequestHandler<GetBranchOfficesListByCityQuery, BranchOfficeListVm>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetBranchOfficesListByCityQueryHandler(IMapper mapper, IKinoDriveDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<BranchOfficeListVm> Handle(GetBranchOfficesListByCityQuery request,
            CancellationToken cancellationToken)
        {
            var list = await _context.BranchOffices
                .Where(x => x.City == request.City)
                .ProjectTo<BranchOfficeLookupDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new BranchOfficeListVm { OfficeList = list };
        }
    }
}
