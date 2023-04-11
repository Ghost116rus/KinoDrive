using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.UserCabinet.Queries.GetUserInfo
{
    public class GetUserInfoQuery : IRequest<UserInfoVm>
    {
        public int UserId { get; set; }
    }
}
