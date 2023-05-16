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

namespace KinoDrive.Aplication.CQRS.Complaints.Queries.GetAllComplaints
{
    public class GetAllComplaintsQueryHandler : IRequestHandler<GetAllComplaintsQuery, List<ComplaintVM>>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetAllComplaintsQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ComplaintVM>> Handle(GetAllComplaintsQuery request, CancellationToken cancellationToken)
        {
            var complaintsList = await _context.Complaints
                .OrderBy(x => x.CreateDate)
                .ProjectTo<ComplaintVM>(_mapper.ConfigurationProvider).ToListAsync();

            return complaintsList;
        }
    }
}
