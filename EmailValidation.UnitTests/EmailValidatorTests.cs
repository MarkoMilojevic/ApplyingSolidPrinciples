using EmailValidation.Builders;
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
            var emailValidator = AEmailValidator().Build();

            Assert.True(emailValidator.IsValid(email));
        }

        [Theory]
        [InlineData("test")]
        [InlineData("test@")]
        [InlineData("test@.com")]
        [InlineData("@outlook.com")]
        public void Should_ReturnFalse_When_FormatIsInvalid(string email)
        {
            var emailValidator = AEmailValidator().Build();

            Assert.False(emailValidator.IsValid(email));
        }

        [Theory]
        [InlineData("test@gmail.com", new[] { "user@gmail.com", "test@microsoft.com", "foo@outlook.com" })]
        public void Should_ReturnTrue_When_IsNotBlacklisted(string email, string[] blacklistedEmails)
        {
            var emailValidator = AEmailValidator()
                                    .ApplyBlacklistedEmailsValidation(blacklistedEmails)
                                    .Build();

            Assert.True(emailValidator.IsValid(email));
        }

        [Theory]
        [InlineData("test@gmail.com", new[] { "user@gmail.com", "test@gmail.com", "foo@outlook.com" })]
        public void Should_ReturnFalse_When_IsBlacklisted(string email, string[] blacklistedEmails)
        {
            var emailValidator = AEmailValidator()
                                    .ApplyBlacklistedEmailsValidation(blacklistedEmails)
                                    .Build();

            Assert.False(emailValidator.IsValid(email));
        }

        [Theory]
        [InlineData("test@gmail.com", new[] { "gmail.com", "microsoft.com", "outlook.com" })]
        public void Should_ReturnTrue_When_DomainIsAllowed(string email, string[] allowedDomains)
        {
            var emailValidator = AEmailValidator()
                                    .ApplyAllowedDomainsValidation(allowedDomains)
                                    .Build();

            Assert.True(emailValidator.IsValid(email));
        }

        [Theory]
        [InlineData("test@gmail.com", new[] { "live.com", "microsoft.com", "outlook.com" })]
        public void Should_ReturnFalse_When_DomainIsNotAllowed(string email, string[] allowedDomains)
        {
            var emailValidator = AEmailValidator()
                                    .ApplyAllowedDomainsValidation(allowedDomains)
                                    .Build();

            Assert.False(emailValidator.IsValid(email));
        }

        [Theory]
        [InlineData(new object[] { new string[] { "test@gmail.com", "test123@outlook.com", "test.test123@nultien.onmicrosoft.com" } })]
        public void Should_ReturnTrue_When_NoDuplicates(string[] emails)
        {
            var emailValidator = AEmailValidator()
                                    .ApplyDuplicatesValidation()
                                    .Build();

            var noDuplicates = true;

            foreach (var email in emails)
            {
                noDuplicates &= emailValidator.IsValid(email);
            }

            Assert.True(noDuplicates);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "test@gmail.com", "test123@outlook.com", "test@gmail.com", "test.test123@nultien.onmicrosoft.com" } })]
        public void Should_ReturnFalse_When_Duplicates(string[] emails)
        {
            var emailValidator = AEmailValidator()
                                    .ApplyDuplicatesValidation()
                                    .Build();

            var noDuplicates = true;

            foreach (var email in emails)
            {
                noDuplicates &= emailValidator.IsValid(email);
            }

            Assert.False(noDuplicates);
        }

        public static EmailValidatorBuilder AEmailValidator()
        {
            return new EmailValidatorBuilder();
        }
    }
}
