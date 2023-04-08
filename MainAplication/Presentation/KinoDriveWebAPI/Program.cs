using KinoDrive.Aplication;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Aplication.Interfaces;
using KinoDrive.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Reflection;
using KinoDrive.Authentication;
using KinoDriveWebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.

services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IKinoDriveDbContext).Assembly));
});

services.AddAplication();
services.AddPersistance(builder.Configuration);
services.AddAuth(builder.Configuration);

services.AddControllers();

services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
});

var app = builder.Build();

using (var scope = services.BuildServiceProvider().CreateScope()) // invoke method of Db initialization
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<KinoDriveDbContext>(); // for accessing dependencies
        DbInitializer.Initialize(context); // initialize database
    }
    catch (Exception e) { }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
