using SolidEmailValidation.Builders;
using Xunit;

namespace SolidEmailValidation.UnitTests
{
    public class AllowedDomainsRule
    {
        [Theory]
        [InlineData("test@gmail.com", new[] { "gmail.com", "microsoft.com", "outlook.com" })]
        public void Should_ReturnTrue_When_DomainIsAllowed(string email, string[] allowedDomains)
        {
            var isValid = new EmailValidatorBuilder()
                                .ApplyAllowedDomainsRule(allowedDomains)
                                .Build()
                                .IsSatisfied(email);

            Assert.True(isValid);
        }

        [Theory]
        [InlineData("test@gmail.com", new[] { "live.com", "microsoft.com", "outlook.com" })]
        public void Should_ReturnFalse_When_DomainIsNotAllowed(string email, string[] allowedDomains)
        {
            var isValid = new EmailValidatorBuilder()
                                .ApplyAllowedDomainsRule(allowedDomains)
                                .Build()
                                .IsSatisfied(email);

            Assert.False(isValid);
        }
    }
}
