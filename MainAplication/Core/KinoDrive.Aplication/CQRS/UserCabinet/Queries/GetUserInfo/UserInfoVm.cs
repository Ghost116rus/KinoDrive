using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.UserCabinet.Queries.GetUserInfo
{
    public class UserInfoVm : IMapWith<User>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserInfoVm>();
        }
    }
}
