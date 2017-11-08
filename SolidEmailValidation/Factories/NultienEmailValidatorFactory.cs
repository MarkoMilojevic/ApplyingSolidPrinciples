using SolidEmailValidation.Builders;
using SolidEmailValidation.Rules;

namespace SolidEmailValidation.Factories
{
    public class NultienEmailValidatorFactory : ICreateEmailValidatorForTenant
    {
        public string TenantName { get; } = "nultien";

        public EmailValidator Create()
        {
            var condition = new EmailValidatorBuilder()
                            .ApplyAllowedDomainsRule(new[] { "nultien.rs", "nultien.com" })
                            .Build();

            var then = new EmailValidatorBuilder()
                            .ApplyBlacklistRule(new[] { "marko.milojevic@nultien.rs" })
                            .Build();

            var @else = new EmailValidatorBuilder()
                            .ApplyNoDuplicatesRule()
                            .Build();

            var nultienRule = new ConditionalValidationRule(condition, then, @else);

            return new EmailValidator(nultienRule);
        }
    }
}
