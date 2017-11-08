using SolidEmailValidation.Builders;
using Xunit;

namespace SolidEmailValidation.UnitTests
{
    public class NoDuplicatesRuleTests
    {
        [Theory]
        [InlineData(new object[] { new string[] { "test@gmail.com", "test123@outlook.com", "test.test123@nultien.onmicrosoft.com" } })]
        public void Should_ReturnTrue_When_NoDuplicates(string[] emails)
        {
            var emailValidator = new EmailValidatorBuilder()
                                        .ApplyNoDuplicatesRule()
                                        .Build();

            var noDuplicates = true;

            foreach (var email in emails)
            {
                noDuplicates &= emailValidator.IsSatisfied(email);
            }

            Assert.True(noDuplicates);
        }

        [Theory]
        [InlineData(new object[] { new string[] { "test@gmail.com", "test123@outlook.com", "test@gmail.com", "test.test123@nultien.onmicrosoft.com" } })]
        public void Should_ReturnFalse_When_Duplicates(string[] emails)
        {
            var emailValidator = new EmailValidatorBuilder()
                                        .ApplyNoDuplicatesRule()
                                        .Build();

            var noDuplicates = true;

            foreach (var email in emails)
            {
                noDuplicates &= emailValidator.IsSatisfied(email);
            }

            Assert.False(noDuplicates);
        }
    }
}
