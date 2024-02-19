using ErrorOr;

namespace Lubricentro.Domain.Common.Errors;

public partial class Errors
{
    public static class Roles
    {
        public static Error Duplicated => Error.Conflict(
            code: "Role.Duplicated",
            description: "El rol ya existe.");
        public static Error NotFound => Error.NotFound(
            code: "Role.NotFound",
            description: "No se pudo encontrar el rol solicitado.");

    }
}
