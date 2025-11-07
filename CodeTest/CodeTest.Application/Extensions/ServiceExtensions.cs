using CodeTest.Application.Abstractions;
using CodeTest.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CodeTest.Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddCoreWebServices(this IServiceCollection services)
    {
        services.AddScoped<IClockConversionService, ClockConversionService>();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }

   
}
