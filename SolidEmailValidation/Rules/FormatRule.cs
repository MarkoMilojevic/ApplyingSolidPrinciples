using System.ComponentModel.DataAnnotations;

namespace SolidEmailValidation.Rules
{
    public class FormatRule : ChainableValidationRule
    {
        public FormatRule(IValidationRule next) : base(next)
        {
        }

        public override bool IsValid(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
