namespace Lubricentro.Domain.OldAggregates;

public record OldClient(int Cli_Codigo,
                        int Tcl_Codigo,
                        int Dcl_Codigo,
                        string Cli_Nombre,
                        string Cli_Cuit,
                        string Cli_Direccion,
                        string Cli_Localidad,
                        string Cli_CP,
                        string Cli_Provincia,
                        string Cli_Telefono,
                        string Cli_Celular,
                        string Cli_Email,
                        bool Cli_Cta_Cte,
                        int Cli_Mayorista)
{
}
