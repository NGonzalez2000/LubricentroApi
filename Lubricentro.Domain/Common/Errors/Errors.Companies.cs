using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lubricentro.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Companies
        {
            public static Error Duplicated => Error.Conflict(
            code: "Company.Duplicated",
            description: "La empresa ya existe.");
            public static Error NotFound => Error.NotFound(
                code: "Company.NotFound",
                description: "No se encontro la empresa solicitada.");
        }
    }
}
