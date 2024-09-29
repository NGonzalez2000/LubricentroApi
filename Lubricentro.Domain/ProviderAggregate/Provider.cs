using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.BrandAggregate;
using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.EmailAggregates;
using Lubricentro.Domain.EmailAggregates.ValueObjects;
using Lubricentro.Domain.PhoneAggregate;
using Lubricentro.Domain.PhoneAggregate.ValueObjects;
using Lubricentro.Domain.ProviderAggregate.ValueObjects;
using Lubricentro.Domain.TaxConditionAggregate;
using System.Numerics;

namespace Lubricentro.Domain.ProviderAggregate;

public class Provider : AggregateRoot<ProviderId, Guid>
{
    public string Name { get; private set; }
    public string Cuil { get; private set; }
    public Address Address { get; private set; }
    public List<Email> Emails { get; private set; }
    public List<Phone> Phones { get; private set; }
    public List<Brand> Brands {  get; private set; }
    public string Fax { get; private set; }
    public string Website { get; private set; }
    public string Observation { get; private set; }
    public TaxCondition TaxCondition { get; private set; }
    private Provider(ProviderId id, string name, string cuil, Address address, List<Phone> phones, string fax, List<Email> emails, string website, string observation, TaxCondition taxCondition) : base(id)
    {
        Name = name;
        Cuil = cuil;
        Address = address;
        Phones = phones;
        Brands = [];
        Fax = fax;
        Emails = emails;
        Website = website;
        Observation = observation;
        TaxCondition = taxCondition;
    }
    public static Provider Create(string name, string cuil, Address address, List<Phone> phones, string fax, List<Email> emails, string website, string observation, TaxCondition taxCondition)
    {
        return new(ProviderId.CreateUnique(),  name, cuil, address, phones, fax, emails, website, observation, taxCondition);
    }
    public void Update(string name, string cuil, string country, string state, string city, string street, string postalCode, string fax, string website, string observation, TaxCondition taxCondition)
    {
        Name = name;
        Cuil = cuil;
        Address.Update(country, state, city, street, postalCode);
        Fax = fax;
        Website = website;
        Observation = observation;
        TaxCondition = taxCondition;
    }

    public void AddEmail(Email email)
    {
        Emails.Add(email);
    }
    public void UpdateEmail(Guid guid, string value, bool isActive)
    {
        var emailId = EmailId.Create(guid);
        Email? temp = Emails.FirstOrDefault(e => e.Id == emailId);
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
    public void UpdatePhone(Guid guid, string nationalId, string value, bool isActive)
    {
        var phoneId = PhoneId.Create(guid);
        Phone? temp = Phones.FirstOrDefault(e => e.Id == phoneId);
        if (temp is null) return;

        temp.Update(nationalId, value, isActive);
    }
    public void DeletePhone(int indx)
    {
        Phones.RemoveAt(indx);
    }

    public void AddBrand(Brand newBrand)
    {
        Brands.Add(newBrand);
    }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    private Provider() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    
}
