using ErrorOr;

namespace Lubricentro.Domain.Common.Errors;

public partial class Errors
{
    public static class Brands
    {
        public static Error DuplicatedName => Error.Conflict(
            code: "Brand.DuplicatedName",
            description: "Ya existe una Marca con ese Nombre");
        public static Error NotFound => Error.NotFound(
            code: "Brand.NotFound",
            description: "No se encontró la Marca solicitada");
    }
}
