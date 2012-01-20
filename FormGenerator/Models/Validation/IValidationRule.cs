namespace FormGenerator.Models.Validation
{
    public interface IValidationRule
    {
        bool Validate(Value value);
        string ValidationMessage { get; }
    }
}