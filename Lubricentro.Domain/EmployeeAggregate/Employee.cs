using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;
using Lubricentro.Domain.UserAggregate;

namespace Lubricentro.Domain.EmployeeAggregate;

public sealed class Employee : AggregateRoot<EmployeeId, Guid>
{
    private Employee(EmployeeId employeeId, User user, string firstName, string lastName, string email)
        : base(employeeId)
    {
        User = user;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
    public User User { get; set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;

    public static Employee Create(User user, string firstName, string lastName, string email)
    {
        var employee = new Employee(
            EmployeeId.CreateUnique(),
            user,
            firstName,
            lastName,
            email);

        return employee;
    }

    public void ChangeFirstName(string firstName)
    {
        FirstName = firstName;
    }

    public void ChangeLastName(string lastName)
    {
        LastName = lastName;
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private Employee() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
