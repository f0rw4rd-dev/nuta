using Nuta.Backend.BuildingBlocks.Domain;

namespace Nuta.Backend.Users.Domain.Aggregates.User.Rules;

public class UserNameMustHaveValidLengthRule : IBusinessRule
{
    private const int MinLength = 2;
    private const int MaxLength = 30;
    
    private string Name { get; }
    
    public UserNameMustHaveValidLengthRule(string name)
    {
        Name = name.Trim();
    }
    
    public bool IsBroken()
    {
        return Name.Length is < MinLength or > MaxLength;
    }

    public string Message => $"Имя пользователя должно иметь длину от {MinLength} до {MaxLength} символов";
}