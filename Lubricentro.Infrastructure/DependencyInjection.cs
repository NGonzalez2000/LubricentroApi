using Lubricentro.Application.Common.Interfaces.Authentication;
using Lubricentro.Application.Common.Interfaces.Services;
using Lubricentro.Infrastructure.Authentication;
using Lubricentro.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Lubricentro.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Lubricentro.Infrastructure.Persistence.Interceptors;
using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Infrastructure.Services.Emails;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Infrastructure.Persistence.Repositories.LubricentroDb;
using Lubricentro.Application.Common.Interfaces.Persistence.OldDb;
using Lubricentro.Infrastructure.Persistence.Repositories.OldDb;
using Lubricentro.Application.Common.Interfaces.Persistence.MigrationDb;
using Lubricentro.Infrastructure.Persistence.Repositories.MigrationDb;

namespace Lubricentro.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddPersistance(configuration);
        services.AddAuth(configuration);
        services.AddServices(configuration);
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IUserProvider, UserProvider>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IPasswordProvider, PasswordProvider>();

        var gmailSettings = new GmailSettings();
        configuration.Bind(GmailSettings.SectionName, gmailSettings);
        services.AddSingleton(Options.Create(gmailSettings));
        
        var outlookSettings = new OutlookSettings();
        configuration.Bind(OutlookSettings.SectionName, outlookSettings);
        services.AddSingleton(Options.Create(outlookSettings));

        services.AddSingleton<IEmailSender, EmailSender>();
        services.AddSingleton<IEmailService, EmailService>();

        services.AddSingleton<ICuilService, CuilService>();
        services.AddSingleton<IImageService, ImageService>();
        return services;
    }

    private static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
    {
        var dbSettings = new DbSettings();
        configuration.Bind(DbSettings.SectionName, dbSettings);
        services.AddDbContext<LubricentroDbContext>(options => options.UseSqlServer(dbSettings.Default));
        services.AddDbContext<MigrationDbContext>(options => options.UseSqlServer(dbSettings.Migration));
        services.AddDbContext<OldDbContext>(options => options.UseSqlServer(dbSettings.Old));
        services.AddLubricentroDb();
        services.AddMigrationDb();
        services.AddOldDb();


        return services;
    }

    private static IServiceCollection AddLubricentroDb(this IServiceCollection services)
    {
        // BASE SERVER
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<LubricentroDbContext>());
        services.AddScoped<PublishDomainEventInterceptor>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IPolicyRepository, PolicyRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ICompanyServiceRepository, CompanyServiceRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ITaxConditionRepository, TaxConditionRepository>();

        return services;
    }

    private static IServiceCollection AddMigrationDb(this IServiceCollection services)
    {
        services.AddScoped<ITaxConditionMigrationRepository, TaxConditionMigrationRepository>();
        services.AddScoped<IClientMigrationRepository, ClientMigrationRepository>();

        return services;
    }

    private static IServiceCollection AddOldDb(this IServiceCollection services)
    {
        services.AddScoped<IOldClientRepository, OldClientRepository>();
        services.AddScoped<IOldTaxConditionRepository, OldTaxConditionRepository>();
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
        var permissionRepository = serviceProvider.GetRequiredService<IPolicyRepository>();

        List<Policy> permissions = permissionRepository.GetAll();

        services.AddAuthorization(options =>
        {
            foreach (var permission in permissions)
            {
                options.AddPolicy($"{permission.Name}", policy =>
                    policy.RequireClaim("Policy", permission.Name));
            }
        });
        return services;
    }
}
