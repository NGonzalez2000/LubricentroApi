namespace Lubricentro.Domain.MigrationAggregates;

public class TaxConditionMigration
{
    public Guid Id { get; set; }
    public string TaxConditionId { get; set; }
    public int Tcl_Codigo { get; set; }
    private TaxConditionMigration(Guid id, string taxConditionId, int tcl_Codigo)
    {
        Id = id;
        TaxConditionId = taxConditionId;
        Tcl_Codigo = tcl_Codigo;
    }

    public static TaxConditionMigration Create(string taxConditionId, int tcl_codigo)
    {
        return new(Guid.NewGuid(), taxConditionId, tcl_codigo);
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private TaxConditionMigration() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
