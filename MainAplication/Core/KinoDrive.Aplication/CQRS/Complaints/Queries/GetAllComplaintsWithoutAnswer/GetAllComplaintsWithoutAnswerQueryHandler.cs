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

namespace KinoDrive.Aplication.CQRS.Complaints.Queries.GetAllComplaintsWithoutAnswer
{
    public class GetAllComplaintsWithoutAnswerQueryHandler
        : IRequestHandler<GetAllComplaintsWithoutAnswerQuery, List<ComplaintVM>>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetAllComplaintsWithoutAnswerQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ComplaintVM>> Handle(GetAllComplaintsWithoutAnswerQuery request,
            CancellationToken cancellationToken)
        {
            var complaintsList = await _context.Complaints
                .Include(x => x.User)
                .Include(x => x.BranchOffice)
                .Where(x => x.Answer == null)
                .OrderByDescending(x => x.CreateDate)
                .ProjectTo<ComplaintVM>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return complaintsList;
        }
    }
}
