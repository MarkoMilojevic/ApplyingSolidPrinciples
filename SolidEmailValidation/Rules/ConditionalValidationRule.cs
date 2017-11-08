using System;

namespace SolidEmailValidation.Rules
{
    public class ConditionalValidationRule : IValidationRule
    {
        private readonly IValidationRule _condition;
        private readonly IValidationRule _then;
        private readonly IValidationRule _else;

        public ConditionalValidationRule(IValidationRule condition, IValidationRule then, IValidationRule @else)
        {
            _condition = condition ?? throw new ArgumentNullException(nameof(condition));
            _then = then ?? throw new ArgumentNullException(nameof(then));
            _else = @else ?? throw new ArgumentNullException(nameof(@else));
        }

        public bool IsSatisfied(string email)
        {
            return _condition.IsSatisfied(email) ? _then.IsSatisfied(email) : _else.IsSatisfied(email);
        }
    }
}
