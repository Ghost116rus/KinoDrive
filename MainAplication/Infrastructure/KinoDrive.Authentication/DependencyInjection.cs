using KinoDrive.Aplication.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KinoDrive.Authentication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "KinoDrive",
                ValidAudience = "KinoDrive",
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("super-secret-key"))
            });

            return services;

        }
    }
}
