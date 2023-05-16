using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.CQRS.Complaints.Common;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Complaints.Queries.GetAllComplaintsByBranchOffice
{
    public class GetAllComplaintsByBranchOfficeQueryHandler : IRequestHandler<GetAllComplaintsByBranchOfficeQuery, List<ComplaintVM>>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetAllComplaintsByBranchOfficeQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ComplaintVM>> Handle(GetAllComplaintsByBranchOfficeQuery request, CancellationToken cancellationToken)
        {
            var manager = await _context.Users.Include(x => x.WorkOffice).FirstOrDefaultAsync(x => x.Id == request.ManagerId && x.Role == "Manager");

            if (manager is null)
            {
                throw new NotFoundException("Не был найден такой менеджер", request.ManagerId);
            }

            if (manager.WorkOffice is null)
            {
                throw new NotFoundException("Не был найден рабочий офис", manager.BranchOfficeId == null ? -1 : manager.BranchOfficeId);
            }

            var complaintsList = await _context.Complaints.Where(x => x.BranchOfficeId == manager.BranchOfficeId)
                .OrderByDescending(x => x.CreateDate)
                .ProjectTo<ComplaintVM>(_mapper.ConfigurationProvider).ToListAsync();

            return complaintsList;
        }

    }
}
