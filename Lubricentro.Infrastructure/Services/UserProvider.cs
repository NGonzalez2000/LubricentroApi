using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.Common.Interfaces.Services;
using Lubricentro.Domain.RoleAggregate;
using Lubricentro.Domain.UserAggregate;
using Lubricentro.Infrastructure.Services.Emails.EmailTemplates;
using System.Threading;

namespace Lubricentro.Infrastructure.Services
{
    public class UserProvider(IPasswordProvider passwordProvider, IUserRepository userRepository,IEmailService emailService) : IUserProvider
    {
        private readonly IPasswordProvider _passwordProvider = passwordProvider;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IEmailService _emailService = emailService;
        public async Task<User> CreateUserAsync(string username, Role role)
        {
            string password = _passwordProvider.GenerateRandomPassword();
            User user = User.Create(username, password, role);

            _userRepository.Add(user);

            await _emailService.SendAsync("nico1_a_gonzalez@hotmail.com",username, "nueva cuenta", EmailTemplates.NewAccount(password));
            return user;
        }
        public async Task<User?> RecoverPasswordAsync(string username)
        {
            if (await _userRepository.GetUserByEmail(username) is not User user)
            {
                return null;
            }

            string password = _passwordProvider.GenerateRandomPassword();

            user.NewPassword(password);

            _userRepository.Update(user);

            await _emailService.SendAsync("nico1_a_gonzalez@hotmail.com",
                                          user.UserName,
                                          "Recuperación de contraseña.",
                                          EmailTemplates.PasswordRecovery(password));
            return user;
        }
    }
}
