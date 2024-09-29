using ErrorOr;

namespace Lubricentro.Domain.Common.Errors
{
    public partial class Errors
    {
        public static class Vehicle
        {
            public static Error Duplicated => Error.Conflict(code:"Vehicle.Duplicated", description:"Ya existe un Vehículo con esa patente.");
            public static Error NotFound => Error.Conflict(code:"Vehicle.NotFound", description:"No se encontró el Vehículo solicitado.");
        }
        public static class VehicleFactory
        {
            public static Error Duplicated => Error.Conflict(code: "VehicleFactory.Duplicated", description: "Ya existe un Fabricante con ese nombre.");
            public static Error NotFound => Error.Conflict(code: "VehicleFactory.NotFound", description: "No se encontró el Fabricante solicitado.");
        }
        public static class VehicleModel
        {
            public static Error Duplicated => Error.Conflict(code: "VehicleModel.Duplicated", description: "Ya existe un Modelo con este nombre para este fabricante.");
            public static Error NotFound => Error.Conflict(code: "VehicleModel.NotFound", description: "No se encontró el Modelo solicitado.");
        }
        public static class VehicleSpecification
        {
            public static Error Duplicated => Error.Conflict(code: "VehicleSpecification.Duplicated", description: "Ya existe una Especificación con este nombre.");
            public static Error NotFound => Error.Conflict(code: "VehicleSpecification.NotFound", description: "No se encontró la Especificación solicitada.");
        }
    }
}
