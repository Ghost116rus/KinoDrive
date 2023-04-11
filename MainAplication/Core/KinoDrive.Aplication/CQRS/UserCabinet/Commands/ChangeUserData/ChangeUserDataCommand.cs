using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.UserCabinet.Commands.ChangeUserData
{
    public class ChangeUserDataCommand : IRequest
    {
        public int UserId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? NickName { get; set; }
        public string? Email { get; set; }
    }
}
