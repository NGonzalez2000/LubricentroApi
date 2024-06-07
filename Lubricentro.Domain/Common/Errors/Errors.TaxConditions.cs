using ErrorOr;

namespace Lubricentro.Domain.Common.Errors
{
    public partial class Errors
    {
        public static class TaxConditions
        {
            public static Error Duplicated => Error.Conflict(code: "TaxCondition.Duplicated", description: "Ya existe una Condición Fiscal con esa descripción.");
            public static Error NotFound => Error.NotFound(code: "TaxCondition.NotFound", description: "No se encontro la Condición Fiscal solicitada.");
        }
    }
}
