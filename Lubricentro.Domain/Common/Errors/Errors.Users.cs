using ErrorOr;

namespace Lubricentro.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "El email ya existe.");
        public static Error CreationFail => Error.Failure(
            code: "User.CreationFail",
            description: "Ocurrió algo inesperado mientras se creaba el nuevo Usuario.");
    }
}
