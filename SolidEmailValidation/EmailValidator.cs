using SolidEmailValidation.Rules;

namespace SolidEmailValidation
{
    public class EmailValidator
    {
        private readonly IValidationRule _rule;

        public EmailValidator(IValidationRule rule)
        {
            _rule = rule;
        }

        public bool IsValid(string email)
        {
            return _rule.IsSatisfied(email);
        }
    }
}
