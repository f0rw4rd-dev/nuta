using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Products.Domain.BusinessRules;

public class Ean13MustHaveValidLengthRule(string ean13) : IBusinessRule
{
    public bool IsBroken()
    {
        return ean13.Length != 13;
    }

    public string Message => "EAN-13 должен содержать 13 символов";
}