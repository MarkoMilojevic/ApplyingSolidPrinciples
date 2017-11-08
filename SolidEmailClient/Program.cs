using SolidEmailValidation;
using SolidEmailValidation.Builders;
using SolidEmailValidation.Factories;
using SolidEmailValidation.Rules;

namespace SolidEmailClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ev1 = new EmailValidator(
                            new FormatRule(
                                new NoDuplicatesRule(
                                    new AlwaysValidRule())));

            var ev2 = new EmailValidatorBuilder()
                            .ApplyBlacklistRule(new[] { "bot@spam.com" })
                            .ApplyAllowedDomainsRule(new[] { "test.com" })
                            .ApplyNoDuplicatesRule()
                            .Build();

            var ev3 = EmailValidatorFactory.CreateFor("nultien");

            var ev4 = EmailValidatorFactory.CreateFor("unknown");
        }
    }
}
