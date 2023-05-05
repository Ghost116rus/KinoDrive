using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KinoDrive.Aplication.CQRS.Managers.Queries.GetManagerList
{
    public class GetManagerListQueryHandler
        : IRequestHandler<GetManagerListQuery, ManagerListVm>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetManagerListQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ManagerListVm> Handle(GetManagerListQuery request, CancellationToken cancellationToken)
        {
            var managers = await _context.Users.Where(x => x.Role == "Manager")
                .ProjectTo<ManagerVm>(_mapper.ConfigurationProvider).ToListAsync();

            return new ManagerListVm { ManagerList = managers };
        }
    }
}
