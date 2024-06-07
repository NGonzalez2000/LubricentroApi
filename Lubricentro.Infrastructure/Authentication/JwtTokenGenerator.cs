using Lubricentro.Application.Common.Interfaces.Authentication;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.Common.Interfaces.Services;
using Lubricentro.Domain.EmployeeAggregate;
using Lubricentro.Domain.PolicyAggregate;
using Lubricentro.Domain.UserAggregate;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lubricentro.Infrastructure.Authentication;

public  class JwtTokenGenerator(IDateTimeProvider dateTimeProvider,IServiceProvider serviceProvider, IOptions<JwtSettings> jwtSettings) : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    public async Task<string> GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        List<string> policies = [];

        using var scope = _serviceProvider.CreateScope();
        var _employeeRepository = scope.ServiceProvider.GetRequiredService<IEmployeeRepository>();

        Employee? employee = await _employeeRepository.GetByEmailAsync(user.UserName);

        string name;
        if(employee is null)
        {
            name = "Nicolas Gonzalez";
        }
        else
        {
            name = $"{employee.FirstName} {employee.LastName}";
        }

        List<Claim> claims =
        [
            new Claim("UserName", name),
            new Claim(ClaimTypes.NameIdentifier, user.Id.Value.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.UserName)
        ];


        
        foreach (Policy policy in user.Role.Policies)
        {
            claims.Add(new("Policy", policy.Name));
        }
        


        



        var secuiryToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(secuiryToken);
    }
}
