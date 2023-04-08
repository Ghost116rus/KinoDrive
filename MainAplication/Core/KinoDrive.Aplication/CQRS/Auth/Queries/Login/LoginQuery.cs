using KinoDrive.Aplication.CQRS.Auth.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Auth.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password
        ) : IRequest<AuthResult>;
}
