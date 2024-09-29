using Lubricentro.Domain.BrandAggregate;
using Lubricentro.Domain.Common.Models;
using Lubricentro.Domain.ProductAggregate.ValueObjects;
using Lubricentro.Domain.ProviderAggregate;

namespace Lubricentro.Domain.ProductAggregate;

public class Product : AggregateRoot<ProductId,Guid>
{
    public string Code { get; private set; }
    public string Barcode { get; private set; }
    public string Description { get; private set; }
    public Provider Provider { get; private set; }
    public Brand Brand { get; private set; }
    public decimal ListPrice { get; private set; }
    public decimal SellPrice { get; private set; }
    public decimal MarkupPercentage { get; private set; }
    public bool IsWholesaler { get; private set; }
    public bool IsUsd { get; private set; }

    private Product(ProductId id, string code, string barcode, string description, Provider provider, Brand brand, decimal listPrice, decimal sellPrice, decimal markupPercentage, bool isWholesaler, bool isUsd)
        : base(id)
    {
        Code = code;
        Barcode = barcode;
        Description = description;
        Provider = provider;
        Brand = brand;
        ListPrice = listPrice;
        SellPrice = sellPrice;
        MarkupPercentage = markupPercentage;
        IsWholesaler = isWholesaler;
        IsUsd = isUsd;
    }

    public static Product Create(string code, string barcode, string description, Provider provider, Brand brand, decimal listPrice, decimal sellPrice, decimal markupPercentage, bool isWholesaler, bool isUsd)
    {
        return new(ProductId.CreateUnique(), code, barcode, description, provider, brand, listPrice, sellPrice, markupPercentage, isWholesaler, isUsd);
    }

    public void Update(string code, string barcode, string description, Provider provider, Brand brand, decimal listPrice, decimal sellPrice, decimal markupPercentage, bool isWholesaler, bool isUsd)
    {
        Code = code;
        Barcode = barcode;
        Description = description;
        Provider = provider;
        Brand = brand;
        ListPrice = listPrice;
        SellPrice = sellPrice;
        MarkupPercentage = markupPercentage;
        IsWholesaler = isWholesaler;
        IsUsd = isUsd;
    }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    private Product()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    {
        
    }

}
