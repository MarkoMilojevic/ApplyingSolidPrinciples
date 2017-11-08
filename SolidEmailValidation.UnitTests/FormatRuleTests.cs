using SolidEmailValidation.Builders;
using Xunit;

namespace SolidEmailValidation.UnitTests
{
    public class FormatRuleTests
    {
        [Theory]
        [InlineData("test@gmail.com")]
        [InlineData("test123@outlook.com")]
        [InlineData("test.test123@nultien.onmicrosoft.com")]
        public void Should_ReturnTrue_When_FormatIsValid(string email)
        {
            var isValid = new EmailValidatorBuilder()
                                .Build()
                                .IsSatisfied(email);

            Assert.True(isValid);
        }

        [Theory]
        [InlineData("test")]
        [InlineData("test@")]
        [InlineData("test@.com")]
        [InlineData("@outlook.com")]
        public void Should_ReturnFalse_When_FormatIsInvalid(string email)
        {
            var isValid = new EmailValidatorBuilder()
                                .Build()
                                .IsSatisfied(email);

            Assert.False(isValid);
        }
    }
}
