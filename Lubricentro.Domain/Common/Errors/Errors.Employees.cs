using ErrorOr;

namespace Lubricentro.Domain.Common.Errors;

public partial class Errors
{
    public static class Employee
    {
        public static Error DuplicatedEmployee => Error.Conflict(
            code: "Employee.DuplicatedEmployee",
            description: "El empleado ya existe.");
        public static Error CreatrionError => Error.Failure(
            code: "Employee.CreationError",
            description: "Error al crear el empleado.");
        public static Error UserCreationError => Error.Failure(
            code: "User.CreationError",
            description: "Error al crear la cuenta de usuario.");
        public static Error EmployeeNotFound => Error.NotFound(
            code: "User.NotFound",
            description: "El empleado solicitado no existe.");
    }
}
