namespace SolidEmailValidation.Rules
{
    public interface IValidationRule
    {
        bool IsSatisfied(string email);
    }
}
