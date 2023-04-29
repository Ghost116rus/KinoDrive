using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Auth.Common
{
    public class AdditionalInfo
    {
        public string NickName { get; set; }
        public string Role { get; set; }
    }
    public record AuthResult(string Token, bool IsSuccess, string? Description, AdditionalInfo? userInfo);
}
