using ErrorOr;

namespace Lubricentro.Domain.Common.Errors;

public partial class Errors
{
    public static class Products
    {
        public static Error Duplicated => Error.Conflict(code: "Product.Duplicated", description: "El código (común o de barra) ya existe.");
        public static Error NotFound => Error.NotFound(code: "Product.NotFound", description: "El producto no se encontró.");
    }
}
