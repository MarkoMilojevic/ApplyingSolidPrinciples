using System;
using System.Collections.Generic;
using System.Linq;

namespace SolidEmailValidation.Rules
{
    public class BlacklistRule : ChainableValidationRule
    {
        private readonly IEnumerable<string> _blacklist;

        public BlacklistRule(IEnumerable<string> blacklist, IValidationRule next) : base(next)
        {
            _blacklist = blacklist ?? throw new ArgumentNullException(nameof(blacklist));
        }

        public override bool IsValid(string email)
        {
            return _blacklist.All(blacklistedEmail => blacklistedEmail != email);
        }
    }
}
