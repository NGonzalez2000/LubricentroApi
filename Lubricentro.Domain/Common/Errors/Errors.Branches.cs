using ErrorOr;

namespace Lubricentro.Domain.Common.Errors;

public partial class Errors
{
    public static class Branches
    {
        public static Error DuplicatedPointOfSale => Error.Conflict(code: "Branch.Duplicated", description: "Ya existe una sucursal con ese Punto de Venta.");
        public static Error NotFound => Error.NotFound(code: "Branch.NotFound", description: "No se encontro la sucursal solicitada.");
    }
}
