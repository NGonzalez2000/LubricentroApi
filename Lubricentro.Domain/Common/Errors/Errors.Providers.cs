using ErrorOr;

namespace Lubricentro.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Providers
        {
            public static Error Duplicated => Error.Conflict(
            code: "Provider.DuplicatedCredentials",
            description: "Ya existe un proveedor con ese NOMBRE o CUIT.");
            public static Error NotFound => Error.NotFound(
            code: "Provider.NotFound",
            description: "No se encontro el proveedor solicitado.");
        }
    }
}
