namespace Lubricentro.Contracts.TaxContitions;

public record UpdateTaxConditionRequest(Guid Id,
                                        string Description,
                                        char Type,
                                        bool Vat)
{
}
