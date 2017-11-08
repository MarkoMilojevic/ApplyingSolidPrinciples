using System;
using System.Collections.Generic;
using System.Linq;

namespace SolidEmailValidation.Rules
{
    public class AllowedDomainsRule : ChainableValidationRule
    {
        private readonly IEnumerable<string> _allowedDomains;

        public AllowedDomainsRule(IEnumerable<string> allowedDomains, IValidationRule next) : base(next)
        {
            _allowedDomains = allowedDomains ?? throw new ArgumentNullException(nameof(allowedDomains));
        }

        public override bool IsValid(string email)
        {
            var emailDomain = email.Split('@')[1];

            return _allowedDomains.Any(domain => domain == emailDomain);
        }
    }
}
