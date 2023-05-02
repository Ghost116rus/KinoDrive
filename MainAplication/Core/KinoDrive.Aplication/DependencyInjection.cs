using FluentValidation;
using KinoDrive.Aplication.Common.AnotherAPI;
using KinoDrive.Aplication.Common.Behaviors;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KinoDrive.Aplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies(new[] {Assembly.GetExecutingAssembly()});
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IKinopoiskAPI, KinopoiskAPI>();
            return services;
        }
    }
}
