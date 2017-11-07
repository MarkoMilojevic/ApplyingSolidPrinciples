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

        private readonly IEnumerable<string> _allowedDomains = Enumerable.Empty<string>();
        private readonly bool _checkIsDomainAllowed = false;

        public EmailValidator()
        {
        }

        public EmailValidator(IEnumerable<string> blacklistedEmails)
        {
            _blacklistedEmails = blacklistedEmails ?? throw new ArgumentNullException(nameof(blacklistedEmails));
            _checkIsEmailBlacklisted = true;
        }

        public EmailValidator(IEnumerable<string> blacklistedEmails, IEnumerable<string> allowedDomains)
                : this(blacklistedEmails)
        {
            _allowedDomains = allowedDomains;
            _checkIsDomainAllowed = true;
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

            if (_checkIsDomainAllowed && IsNotAllowedDomain(email))
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

        private bool IsNotAllowedDomain(string email)
        {
            var emailDomain = email.Split('@')[1];

            var isAllowed = _allowedDomains.Any(domain => domain == emailDomain);

            return !isAllowed;
        }
    }
}
