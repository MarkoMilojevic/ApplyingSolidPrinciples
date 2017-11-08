using System;

namespace SolidEmailValidation.Rules
{
    public abstract class ChainableValidationRule : IValidationRule
    {
        protected readonly IValidationRule Next;

        public ChainableValidationRule(IValidationRule next)
        {
            Next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public virtual bool IsSatisfied(string email)
        {
            return IsValid(email) && Next.IsSatisfied(email);
        }

        public abstract bool IsValid(string email);
    }
}
