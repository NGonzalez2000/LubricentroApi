using ErrorOr;

namespace Lubricentro.Domain.Common.Errors;

public static partial class Errors
{
    public static class Clients
    {
        public static Error DuplicatedCuil => Error.Conflict(
            code: "Client.DuplicatedCuil",
            description: "Ya existe un cliente con ese CUIL/CUIT");
        public static Error NotFounnd => Error.NotFound(
            code: "Client.NotFound",
            description: "No se encontró el cliente solicitado");
    }
}
