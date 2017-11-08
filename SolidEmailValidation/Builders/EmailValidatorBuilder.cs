using SolidEmailValidation.Rules;
using System;
using System.Collections.Generic;

namespace SolidEmailValidation.Builders
{
    public class EmailValidatorBuilder
    {
        private List<Type> _ruleTypesByPriority;
        private Dictionary<Type, Func<int, IValidationRule>> _createRuleForType;

        public EmailValidatorBuilder()
        {
            _ruleTypesByPriority = new List<Type>
            {
                typeof(FormatRule),
                typeof(BlacklistRule),
                typeof(AllowedDomainsRule),
                typeof(NoDuplicatesRule),
                typeof(AlwaysValidRule)
            };

            _createRuleForType = new Dictionary<Type, Func<int, IValidationRule>>
            {
                { typeof(FormatRule), (next) => new FormatRule(Build(next)) },
                { typeof(BlacklistRule), (next) => Build(next) },
                { typeof(AllowedDomainsRule), (next) => Build(next) },
                { typeof(NoDuplicatesRule), (next) => Build(next) },
                { typeof(AlwaysValidRule), (next) => new AlwaysValidRule() }
            };
        }

        public EmailValidatorBuilder ApplyBlacklistRule(IEnumerable<string> blacklistedEmails)
        {
            _createRuleForType[typeof(BlacklistRule)] = (next) => new BlacklistRule(blacklistedEmails, Build(next));

            return this;
        }

        public EmailValidatorBuilder ApplyAllowedDomainsRule(IEnumerable<string> allowedDomains)
        {
            _createRuleForType[typeof(AllowedDomainsRule)] = (next) => new AllowedDomainsRule(allowedDomains, Build(next));

            return this;
        }

        public EmailValidatorBuilder ApplyNoDuplicatesRule()
        {
            _createRuleForType[typeof(NoDuplicatesRule)] = (next) => new NoDuplicatesRule(Build(next));

            return this;
        }

        public IValidationRule Build()
        {
            return Build(0);
        }

        private IValidationRule Build(int rulePriority)
        {
            var ruleType = _ruleTypesByPriority[rulePriority];

            return _createRuleForType[ruleType](rulePriority + 1);
        }
    }
}
