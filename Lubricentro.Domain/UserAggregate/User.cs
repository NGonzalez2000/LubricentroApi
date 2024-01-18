using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;
using Lubricentro.Domain.UserAggregate.ValueObjects;

namespace Lubricentro.Domain.UserAggregate;

public class User : AggregateRoot<UserId, Guid>
{
    private User(UserId id, EmployeeId employeeId, string email, string password )
        : base(id)
    {
        EmployeeId = employeeId;
        Email = email;
        Password = password;
    }
    public EmployeeId EmployeeId { get; } = null!;
    public string Email { get; } = null!;
    public string Password { get; } = null!;
    public static User Create(EmployeeId employeeId, string email, string password)
    {
        return new(
            UserId.CreateUnique(),
            employeeId,
            email,
            password);
    }
    private User() { }
}
