using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.BusinessRules;

public class UserNameMustHaveValidLengthRule(string name) : IBusinessRule
{
    private const int MinLength = 2;
    private const int MaxLength = 30;
    
    private string Name { get; } = name.Trim();

    public bool IsBroken()
    {
        return Name.Length is < MinLength or > MaxLength;
    }

    public string Message => $"Имя пользователя должно иметь длину от {MinLength} до {MaxLength} символов";
}