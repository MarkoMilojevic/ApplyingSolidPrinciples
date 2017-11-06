using System.Net.Mail;

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
            try
            {
                new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
