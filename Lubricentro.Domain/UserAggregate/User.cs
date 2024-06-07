using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.RoleAggregate;
using Lubricentro.Domain.UserAggregate.ValueObjects;
using System.Security.Cryptography;
using System.Text;

namespace Lubricentro.Domain.UserAggregate;

public class User : AggregateRoot<UserId, Guid>
{
    private User(UserId id, string userName, string password, string salt, Role role)
        : base(id)
    {
        UserName = userName;
        Password = password;
        Role = role;
        Salt = salt;
    }
    public string UserName { get; } = null!;
    public string Password { get; private set; } = null!;
    public string Salt { get; private set; } = null!;
    public Role Role { get; set; } 

    public void NewPassword(string password)
    {
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        string saltstr = Convert.ToBase64String(salt);
        string saltedPassword = password + saltstr;

        // Calcular el hash de la cadena
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(saltedPassword));
        Password = Convert.ToBase64String(hash);
        Salt = saltstr;
    }
    public static User Create(string userName, string password, Role role)
    {
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        string saltstr = Convert.ToBase64String(salt);
        string saltedPassword = password + saltstr;

        // Calcular el hash de la cadena
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(saltedPassword));
        string hashedPassword = Convert.ToBase64String(hash);
        return new(
            UserId.CreateUnique(),
            userName,
            hashedPassword,
            saltstr,
            role);
    }
    public bool PasswordCheck(string password)
    {
        string saltedPassword = password + Salt;

        // Calcular el hash de la cadena
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(saltedPassword));
        string hashedPassword = Convert.ToBase64String(hash);

        return hashedPassword == Password;
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private User() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
