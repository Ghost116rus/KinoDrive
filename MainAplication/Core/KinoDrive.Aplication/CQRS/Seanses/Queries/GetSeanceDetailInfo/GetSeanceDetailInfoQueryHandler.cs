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

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetSeanceDetailInfo
{
    public class GetSeanceDetailInfoQueryHandler
        :IRequestHandler<GetSeanceDetailInfoQuery, SeanceDetailInfoVm>
    {
        private readonly IMapper mapper;
        private readonly IKinoDriveDbContext kinoDriveDbContext;

        public GetSeanceDetailInfoQueryHandler(IMapper mapper, IKinoDriveDbContext kinoDriveDbContext)
        {
            this.mapper = mapper;
            this.kinoDriveDbContext = kinoDriveDbContext;
        }


        public async Task<SeanceDetailInfoVm> Handle(GetSeanceDetailInfoQuery request,
            CancellationToken cancellationToken)
        {
            var seanceInfo = await kinoDriveDbContext.Seances
                .Where(s => s.Id == request.SeanceId)
                .ProjectTo<SeanceDetailInfoVm>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (seanceInfo == null)
            {
                return null;
            }

            seanceInfo.Places = await kinoDriveDbContext.Bookings
                .Where(b => b.SeanceId == request.SeanceId)
                .ProjectTo<BookingPlaceVM>(mapper.ConfigurationProvider)
                .ToListAsync();

            return seanceInfo;
        }
    }
}
