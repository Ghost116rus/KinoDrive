using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficeDetailInfoForAdmin
{
    public class GetBranchOfficeDetailInfoForAdminQueryHandler
        :IRequestHandler<GetBranchOfficeDetailInfoForAdminQuery, DetailInfoOfBranchOfficeForAdmin>
    {
        private readonly IMapper _mapper;
        private readonly IKinoDriveDbContext _kinoDriveDbContext;

        public GetBranchOfficeDetailInfoForAdminQueryHandler(IMapper mapper, IKinoDriveDbContext kinoDriveDbContext)
        {
            _mapper = mapper;
            _kinoDriveDbContext = kinoDriveDbContext;
        }

        public async Task<DetailInfoOfBranchOfficeForAdmin> Handle(GetBranchOfficeDetailInfoForAdminQuery request,
            CancellationToken cancellationToken)
        {
            var branchOffice = await 
                _kinoDriveDbContext.BranchOffices
                .ProjectTo<DetailInfoOfBranchOfficeForAdmin>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.BranchOfficeId);

            if (branchOffice is null)
            {
                throw new NotFoundException("BranchOffice", request.BranchOfficeId);
            }

            var cinemaHalls = await _kinoDriveDbContext.CinemaHalls
                .Where(c => c.OfficeId == request.BranchOfficeId)
                .ProjectTo<CinemaHallLookupDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            branchOffice.CinemaHallsList = cinemaHalls;

            return branchOffice;
        }

    }
}
