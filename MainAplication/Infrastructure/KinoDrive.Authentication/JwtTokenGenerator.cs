using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KinoDrive.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-key")),
            SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: "KinoDrive",
                audience: "KinoDrive",
                expires: DateTime.UtcNow.AddMinutes(60),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
