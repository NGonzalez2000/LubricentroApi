using ErrorOr;

namespace Lubricentro.Domain.Common.Errors
{
    public partial class Errors
    {
        public static class Policies
        {
            public static Error NotFound => Error.NotFound(
            code: "Policy.NotFound",
            description: "No se pudo encontrar la politica solicitada.");
        }
    }
}
