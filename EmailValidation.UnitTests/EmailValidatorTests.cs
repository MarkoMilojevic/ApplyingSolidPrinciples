using Xunit;

namespace EmailValidation.UnitTests
{
    public class EmailValidatorTests
    {
        [Theory]
        [InlineData("test@gmail.com")]
        [InlineData("test123@outlook.com")]
        [InlineData("test.test123@nultien.onmicrosoft.com")]
        public void Should_ReturnTrue_When_EmailIsValid(string email)
        {
            Assert.True(new EmailValidator().IsValid(email));
        }

        [Theory]
        [InlineData("test")]
        [InlineData("test@")]
        [InlineData("test@.com")]
        [InlineData("@outlook.com")]
        public void Should_ReturnFalse_When_EmailIsInvalid(string email)
        {
            Assert.False(new EmailValidator().IsValid(email));
        }
    }
}
