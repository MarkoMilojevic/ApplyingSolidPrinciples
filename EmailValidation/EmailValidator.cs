using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EmailValidation
{
    public class EmailValidator
    {
        private readonly IEnumerable<string> _blacklistedEmails = Enumerable.Empty<string>();
        private readonly bool _checkIsEmailBlacklisted = false;

        public EmailValidator()
        {
        }

        public EmailValidator(IEnumerable<string> blacklistedEmails)
        {
            _blacklistedEmails = blacklistedEmails ?? throw new ArgumentNullException(nameof(blacklistedEmails));
            _checkIsEmailBlacklisted = true;
        }

        public bool IsValid(string email)
        {
            if (IsNotValidFormat(email))
            {
                return false;
            }

            if (_checkIsEmailBlacklisted && IsEmailBlacklisted(email))
            {
                return false;
            }

            return true;
        }

        private bool IsNotValidFormat(string email)
        {
            var isValid = new EmailAddressAttribute().IsValid(email);

            return !isValid;
        }

        private bool IsEmailBlacklisted(string email)
        {
            return _blacklistedEmails.Any(blacklistedEmail => blacklistedEmail == email);
        }
    }
}
