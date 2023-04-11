using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.UserCabinet.Queries.GetUserInfo
{
    public class GetUserInfoQueryHandler
        :IRequestHandler<GetUserInfoQuery, UserInfoVm>
    {
        private readonly IMapper _mapper;
        private readonly IKinoDriveDbContext _kinoDriveDbContext;

        public GetUserInfoQueryHandler(IMapper mapper, IKinoDriveDbContext kinoDriveDbContext)
        {
            _mapper = mapper;
            _kinoDriveDbContext = kinoDriveDbContext;
        }

        public async Task<UserInfoVm> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var userInfoVm = await _kinoDriveDbContext.Users
                .FirstOrDefaultAsync(user => user.Id == request.UserId);

            if (userInfoVm == null)
            {
                throw new NotFoundException("User", -1);
            }

            return _mapper.Map<UserInfoVm>(userInfoVm); 
        }
    }
}
