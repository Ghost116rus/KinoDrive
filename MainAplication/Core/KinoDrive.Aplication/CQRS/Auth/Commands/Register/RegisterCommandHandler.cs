using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.CQRS.Auth.Common;
using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KinoDrive.Aplication.CQRS.Auth.Commands.Register
{
    public class RegisterCommandHandler
        : IRequestHandler<RegisterCommand, AuthResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IKinoDriveDbContext _context;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IKinoDriveDbContext context)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _context = context;
        }

        public async Task<AuthResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == request.Email);

            if (user is not null)
            {
                throw new RegisterException();
            }

            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                NickName = request.NickName,
                Role = request.Role,
            };

            _context.Users.Add(newUser);

            await _context.SaveChangesAsync(cancellationToken);

            var token = _jwtTokenGenerator.GenerateToken(newUser);

            return new AuthResult(token, true, "", new AdditionalInfo { NickName = newUser.NickName, Role = newUser.Role });
        }
    }
}
