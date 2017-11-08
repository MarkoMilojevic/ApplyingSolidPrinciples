using SolidEmailValidation.Rules;
using Xunit;

namespace SolidEmailValidation.UnitTests
{
    public class AlwaysValidRuleTests
    {
        [Theory]
        [InlineData("test@gmail.com")]
        [InlineData("test123@outlook.com")]
        [InlineData("test.test123@nultien.onmicrosoft.com")]
        [InlineData("test")]
        [InlineData("test@")]
        [InlineData("test@.com")]
        [InlineData("@outlook.com")]
        [InlineData("")]
        [InlineData(null)]
        public void Should_ReturnTrue_When_FormatIsValid(string email)
        {
            var isValid = new AlwaysValidRule().IsSatisfied(email);

            Assert.True(isValid);
        }
    }
}
