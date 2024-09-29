using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Authentication;
using Lubricentro.Domain.Common.Errors;
using MediatR;
using Lubricentro.Application.Authentication.Common;
using Lubricentro.Domain.UserAggregate;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using Lubricentro.Domain.CompanyAggregate.Entities;

namespace Lubricentro.Application.Authentication.Queries.Login;

public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IBranchRepository branchRepository) :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Validate if user exists

        if (await _userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Validate if password is correct
        if (!user.PasswordCheck(query.Password))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if(branchRepository.GetById(BranchId.Create(query.BranchId)).Result is null)
        {
            return Errors.Branches.NotFound;
        }

        // Create JWT token
        var token = await _jwtTokenGenerator.GenerateToken(user, BranchId.Create(query.BranchId));

        return new AuthenticationResult(
            user.Id.Value.ToString()!,
            user.UserName,
            token);
    }
}
