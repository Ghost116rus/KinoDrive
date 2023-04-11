using MediaCore.Aplication.Interfaces;
using MediaServer.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaServer.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDAL(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<MediaServerContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IMediaServerContext>(provider =>
                provider.GetService<MediaServerContext>());

            return services;
        }
    }
}
