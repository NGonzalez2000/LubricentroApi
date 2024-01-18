using Lubricentro.Application.Common.Interfaces.Authentication;
using Lubricentro.Application.Common.Interfaces.Services;
using Lubricentro.Infrastructure.Authentication;
using Lubricentro.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Lubricentro.Application.Common.Interfaces.Persistence;
using Lubricentro.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Lubricentro.Infrastructure.Persistence.Repositories;
using Lubricentro.Infrastructure.Persistence.Interceptors;
using Lubricentro.Domain.PermissionAggregate;
using Lubricentro.Infrastructure.Authorization;

namespace Lubricentro.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddPersistance(configuration);
        services.AddAuth(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IPasswordProvider, PasswordProvider>();

        return services;
    }

    private static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<LubricentroDbContext>(options => options.UseSqlServer("Server=DESKTOP-AHS4M28;Database=Lubricentro;User Id=sa;Password=aaoem;"));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<LubricentroDbContext>());
        services.AddScoped<PublishDomainEventInterceptor>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        return services;
    }

    

    private static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        using var serviceProvider = services.BuildServiceProvider();
        var permissionRepository = serviceProvider.GetRequiredService<IPermissionRepository>();

        List<Permission> permissions = permissionRepository.GetAll();

        services.AddAuthorization(options =>
        {
            foreach (var permission in permissions)
            {
                options.AddPolicy($"{permission}Policy", policy =>
                    policy.Requirements.Add(new PermissionRequirement(permission.Name)));
            }
        });
        return services;
    }
}
