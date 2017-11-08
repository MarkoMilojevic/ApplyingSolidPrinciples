using SolidEmailValidation.Builders;
using Xunit;

namespace SolidEmailValidation.UnitTests
{
    public class BlacklistRuleTests
    {
        [Theory]
        [InlineData("test@gmail.com", new[] { "user@gmail.com", "test@microsoft.com", "foo@outlook.com" })]
        public void Should_ReturnTrue_When_IsNotBlacklisted(string email, string[] blacklistedEmails)
        {
            var isValid = new EmailValidatorBuilder()
                                .ApplyBlacklistRule(blacklistedEmails)
                                .Build()
                                .IsSatisfied(email);

            Assert.True(isValid);
        }

        [Theory]
        [InlineData("test@gmail.com", new[] { "user@gmail.com", "test@gmail.com", "foo@outlook.com" })]
        public void Should_ReturnFalse_When_IsBlacklisted(string email, string[] blacklistedEmails)
        {
            var isValid = new EmailValidatorBuilder()
                                .ApplyBlacklistRule(blacklistedEmails)
                                .Build()
                                .IsSatisfied(email);

            Assert.False(isValid);
        }
    }
}
