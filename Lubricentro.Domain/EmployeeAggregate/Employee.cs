using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.EmployeeAggregate.ValueObjects;

namespace Lubricentro.Domain.EmployeeAggregate;

public sealed class Employee : AggregateRoot<EmployeeId, Guid>
{
    private Employee(EmployeeId employeeId, string firstName, string lastName, string email)
        : base(employeeId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;

    public static Employee Create(string firstName, string lastName, string email)
    {
        var employee = new Employee(
            EmployeeId.CreateUnique(),
            firstName,
            lastName,
            email);

        return employee;
    }
    private Employee() { }
}
