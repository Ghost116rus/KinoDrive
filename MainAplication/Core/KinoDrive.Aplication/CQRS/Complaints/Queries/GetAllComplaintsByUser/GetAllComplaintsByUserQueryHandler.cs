using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.CQRS.Complaints.Common;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Complaints.Queries.GetAllComplaintsByUser
{
    public class GetAllComplaintsByUserQueryHandler : IRequestHandler<GetAllComplaintsByUserQuery, List<ComplaintVM>>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public async Task<List<ComplaintVM>> Handle(GetAllComplaintsByUserQuery request, CancellationToken cancellationToken)
        {
            var complaintList = await _context.Complaints.Where(x => x.UserId == request.UserId)
                .OrderBy(x => x.CreateDate)
                .ProjectTo<ComplaintVM>(_mapper.ConfigurationProvider).ToListAsync();

            return complaintList;
        }
    }
}
