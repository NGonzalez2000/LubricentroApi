using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.RoleAggregate;
using Lubricentro.Domain.UserAggregate.ValueObjects;

namespace Lubricentro.Domain.UserAggregate;

public class User : AggregateRoot<UserId, Guid>
{
    private User(UserId id, string userName, string password, Role roleId)
        : base(id)
    {
        UserName = userName;
        Password = password;
        Role = roleId;
    }
    public string UserName { get; } = null!;
    public string Password { get; } = null!;
    public Role Role { get; set; } 
    public static User Create(string userName, string password, Role roleId)
    {
        return new(
            UserId.CreateUnique(),
            userName,
            password,
            roleId);
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private User() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
