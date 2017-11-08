namespace SolidEmailValidation.Rules
{
    public class AlwaysValidRule : IValidationRule
    {
        public bool IsSatisfied(string email)
        {
            return true;
        }
    }
}
