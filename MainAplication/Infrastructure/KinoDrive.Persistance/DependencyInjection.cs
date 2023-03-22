using KinoDrive.Aplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<KinoDriveDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IKinoDriveDbContext>(provider =>
                provider.GetService<KinoDriveDbContext>());

            return services;

        }
    }
}
