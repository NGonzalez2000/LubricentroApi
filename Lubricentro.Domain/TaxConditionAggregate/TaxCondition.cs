using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;

namespace Lubricentro.Domain.TaxConditionAggregate;

public class TaxCondition : AggregateRoot<TaxConditionId, Guid>
{
    public string Description { get; set; }
    public char Type { get; set; }
    public bool VAT { get; set; }

    private TaxCondition(TaxConditionId Id, string description, char type, bool vat)
        : base(Id)
    {
        Description = description;
        Type = type;
        VAT = vat;
    }

    public static TaxCondition Create(string description, char type, bool vat)
    {
        return new(TaxConditionId.CreateUnique(),  description, type, vat);
    }

    public void Update(string description, char type, bool vat)
    {
        Description = description;
        Type = type;
        VAT = vat;
    }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private TaxCondition()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    {
            
    }
}
