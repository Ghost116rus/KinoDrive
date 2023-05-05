using AutoMapper;
using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Managers.Queries.GetManager
{
    public class GetManagerQueryHandler
        : IRequestHandler<GetManagerQuery, ManagerVm>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetManagerQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ManagerVm> Handle(GetManagerQuery request, 
            CancellationToken cancellationToken)
        {
            var manager = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.Role == "Manager");

            if (manager is null)
            {
                throw new NotFoundException("Пользователь не найден", request.Id);
            }

            return _mapper.Map<ManagerVm>(manager);
        }


    }
}
