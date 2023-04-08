using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.CQRS.Auth.Common;
using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Auth.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IKinoDriveDbContext _context;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IKinoDriveDbContext context)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _context = context;
        }

        public async Task<AuthResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user is not null)
            {
                if (user.Password == request.Password)
                {
                    var jwtToken = _jwtTokenGenerator.GenerateToken(user);
                    return new AuthResult(jwtToken, true, "");
                }
            }

            throw new NotFoundException(nameof(User), request.Email);
        }
    }
}
