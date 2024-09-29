using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.ClientAggregate.ValueObjects;
using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.EmailAggregates;
using Lubricentro.Domain.EmailAggregates.ValueObjects;
using Lubricentro.Domain.PhoneAggregate;
using Lubricentro.Domain.PhoneAggregate.ValueObjects;
using Lubricentro.Domain.TaxConditionAggregate;
using System.Numerics;

namespace Lubricentro.Domain.ClientAggregate;

public class Client : AggregateRoot<ClientId, Guid>
{
    public Address Address { get; private set; }
    public TaxCondition TaxCondition { get; private set; }
    public string ClientName { get; private set; }
    public string Cuil {  get; private set; }
    public bool HasEmailNotification { get; private set; }
    public List<Email> Emails { get; private set; }
    public bool HasPhoneNotification { get; private set; }
    public List<Phone> Phones { get; private set; }
    public string Observation { get; private set; }
    public bool HasCheckingAccount { get; private set; }
    public bool IsWholesaler { get; private set; }

    private Client(ClientId id, Address address,TaxCondition taxCondition, string clientName, string cuil, bool hasEmailNotification, List<Email> emails, bool hasPhoneNotification, List<Phone> phones, string observation, bool hasCheckingAccount, bool isWholesaler)
        : base(id)
    {
        Address = address;
        TaxCondition = taxCondition;
        ClientName = clientName;
        Cuil = cuil;
        HasEmailNotification = hasEmailNotification;
        Emails = emails;
        HasPhoneNotification = hasPhoneNotification;
        Phones = phones;
        Observation = observation;
        HasCheckingAccount = hasCheckingAccount;
        IsWholesaler = isWholesaler;
    }

    public static Client Create(Address address,
                                TaxCondition taxCondition,
                                string clientName,
                                string cuil,
                                bool hasEmailNotification,
                                List<Email> emails,
                                bool hasPhoneNotification,
                                List<Phone> phones,
                                string observation,
                                bool hasCheckingAccount,
                                bool isWholesaler)
    {
        return new(ClientId.CreateUnique(), address, taxCondition, clientName, cuil,hasEmailNotification, emails, hasPhoneNotification, phones, observation, hasCheckingAccount, isWholesaler);
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
        bool hasEmailNotification,
        bool hasPhoneNotification,
        string observation,
        bool hasCheckingAccount,
        bool isWholesaler)
    {
        Address.Update(country, state, city, street, postalCode);
        TaxCondition = taxCondition;
        ClientName = clientName;
        Cuil = cuil;
        Observation = observation;
        HasCheckingAccount = hasCheckingAccount;
        IsWholesaler = isWholesaler;
        HasEmailNotification = hasEmailNotification;
        HasPhoneNotification = hasPhoneNotification;
    }
    public void AddEmail(Email email)
    {
        Emails.Add(email);
    }
    public void UpdateEmail(Guid guid, string value, bool isActive)
    {
        var emailId = EmailId.Create(guid);
        Email? temp = Emails.FirstOrDefault(e => e.Id ==  emailId);
        if (temp is null) return;

        temp.Update(value, isActive);
    }
    public void DeleteEmail(int indx)
    {
        Emails.RemoveAt(indx);
    }

    public void AddPhone(Phone phone)
    {
        Phones.Add(phone);
    }
    public void UpdatePhone(Guid guid, string NationalId, string value, bool isActive)
    {
        var phoneId = PhoneId.Create(guid);
        Phone? temp = Phones.FirstOrDefault(e => e.Id == phoneId);
        if (temp is null) return;

        temp.Update(NationalId, value, isActive);
    }
    public void DeletePhone(int indx)
    {
        Phones.RemoveAt(indx);
    }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private Client() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}
