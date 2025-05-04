namespace Nuta.Backend.BuildingBlocks.Domain;

public class BusinessRuleValidationException(IBusinessRule brokenRule) : Exception(brokenRule.Message)
{
    public IBusinessRule BrokenRule { get; } = brokenRule;

    public string Details { get; } = brokenRule.Message;

    public override string ToString()
    {
        return $"Бизнес-правило {BrokenRule.GetType().FullName} нарушено. Message = {BrokenRule.Message}";
    }
}