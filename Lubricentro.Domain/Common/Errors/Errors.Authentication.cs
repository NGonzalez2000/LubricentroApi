using ErrorOr;

namespace Lubricentro.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "Auth.InvalidCred",
                description: "Usuario o contraseña incorrecta.");
        }
    }
}
