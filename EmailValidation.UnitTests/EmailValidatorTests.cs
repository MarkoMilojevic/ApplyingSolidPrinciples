using Xunit;

namespace EmailValidation.UnitTests
{
    public class EmailValidatorTests
    {
        [Theory]
        [InlineData("test@gmail.com")]
        [InlineData("test123@outlook.com")]
        [InlineData("test.test123@nultien.onmicrosoft.com")]
        public void Should_ReturnTrue_When_FormatIsValid(string email)
        {
            Assert.True(new EmailValidator().IsValid(email));
        }

        [Theory]
        [InlineData("test")]
        [InlineData("test@")]
        [InlineData("test@.com")]
        [InlineData("@outlook.com")]
        public void Should_ReturnFalse_When_FormatIsInvalid(string email)
        {
            Assert.False(new EmailValidator().IsValid(email));
        }

        [Theory]
        [InlineData("test@gmail.com", new[] { "user@gmail.com", "test@microsoft.com", "foo@outlook.com" })]
        public void Should_ReturnTrue_When_IsNotBlacklisted(string email, string[] blacklistedEmails)
        {
            Assert.True(new EmailValidator(blacklistedEmails).IsValid(email));
        }

        [Theory]
        [InlineData("test@gmail.com", new[] { "user@gmail.com", "test@gmail.com", "foo@outlook.com" })]
        public void Should_ReturnFalse_When_IsBlacklisted(string email, string[] blacklistedEmails)
        {
            Assert.False(new EmailValidator(blacklistedEmails).IsValid(email));
        }

        [Theory]
        [InlineData("test@gmail.com", new[] { "gmail.com", "microsoft.com", "outlook.com" })]
        public void Should_ReturnTrue_When_DomainIsAllowed(string email, string[] allowedDomains)
        {
            Assert.True(new EmailValidator(new string[] { }, allowedDomains).IsValid(email));
        }

        [Theory]
        [InlineData("test@gmail.com", new[] { "live.com", "microsoft.com", "outlook.com" })]
        public void Should_ReturnFalse_When_DomainIsNotAllowed(string email, string[] allowedDomains)
        {
            Assert.False(new EmailValidator(new string[] { }, allowedDomains).IsValid(email));
        }
    }
}
