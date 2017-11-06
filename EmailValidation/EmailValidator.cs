using System.ComponentModel.DataAnnotations;

namespace EmailValidation
{
    public class EmailValidator
    {
        public bool IsValid(string email)
        {
            return IsFormatValid(email);
        }

        private bool IsFormatValid(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
