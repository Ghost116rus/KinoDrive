using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Auth.Common
{
    public record AuthResult(string Token, bool IsSuccess, string? Description);
}
