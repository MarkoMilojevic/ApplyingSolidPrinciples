using System.Collections.Generic;

namespace SolidEmailValidation.Rules
{
    public class NoDuplicatesRule : ChainableValidationRule
    {
        private readonly ISet<string> _processedEmails = new HashSet<string>();

        public NoDuplicatesRule(IValidationRule next) : base(next)
        {
        }

        public override bool IsValid(string email)
        {
            if (_processedEmails.Contains(email))
            {
                return false;
            }

            _processedEmails.Add(email);

            return true;
        }
    }
}
