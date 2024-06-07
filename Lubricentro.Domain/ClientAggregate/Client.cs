using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.ClientAggregate.ValueObjects;
using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.TaxConditionAggregate;
using Lubricentro.Domain.TaxConditionAggregate.ValueObjects;

namespace Lubricentro.Domain.ClientAggregate;

public class Client : AggregateRoot<ClientId, Guid>
{
    public Address Address { get; set; }
    public TaxCondition TaxCondition { get; set; }
    public string ClientName { get; set; }
    public string Cuil {  get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string CellphoneNumber { get; set; }
    public string Observation { get; set; }
    public bool HasCheckingAccount { get; set; }
    public bool IsWholesaler { get; set; }

    private Client(ClientId id, Address address,TaxCondition taxCondition, string clientName, string cuil, string email, string phoneNumber, string cellphoneNumber, string observation, bool hasCheckingAccount, bool isWholesaler)
        : base(id)
    {
        Address = address;
        TaxCondition = taxCondition;
        ClientName = clientName;
        Cuil = cuil;
        Email = email;
        PhoneNumber = phoneNumber;
        CellphoneNumber = cellphoneNumber;
        Observation = observation;
        HasCheckingAccount = hasCheckingAccount;
        IsWholesaler = isWholesaler;
    }

    public static Client Create(Address address,TaxCondition taxCondition, string clientName, string cuil, string email, string phoneNumber, string cellphoneNumber, string observation, bool hasCheckingAccount, bool isWholesaler)
    {
        return new(ClientId.CreateUnique(), address, taxCondition, clientName, cuil, email, phoneNumber, cellphoneNumber, observation, hasCheckingAccount, isWholesaler);
    }

    public void Update(
        string country,
        string state,
        string city,
        string street,
        string postalCode,
        TaxCondition taxCondition,
        string clientName,
        string cuil,
        string email,
        string phoneNumber,
        string cellphoneNumber,
        string observation,
        bool hasCheckingAccount,
        bool isWholesaler)
    {
        Address.Update(country, state, city, street, postalCode);
        TaxCondition = taxCondition;
        ClientName = clientName;
        Cuil = cuil;
        Email = email;
        PhoneNumber = phoneNumber;
        CellphoneNumber = cellphoneNumber;
        Observation = observation;
        HasCheckingAccount = hasCheckingAccount;
        IsWholesaler = isWholesaler;
    }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private Client() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
