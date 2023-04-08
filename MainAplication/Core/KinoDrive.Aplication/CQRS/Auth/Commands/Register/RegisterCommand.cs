using KinoDrive.Aplication.CQRS.Auth.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Auth.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string NickName) : IRequest<AuthResult>;
}
