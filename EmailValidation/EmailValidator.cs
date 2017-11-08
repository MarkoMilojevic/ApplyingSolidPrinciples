using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EmailValidation
{
    public class EmailValidator
    {
        private readonly IEnumerable<string> _blacklistedEmails;
        private readonly bool _checkIsEmailBlacklisted;

        private readonly IEnumerable<string> _allowedDomains;
        private readonly bool _checkIsDomainAllowed;

        private readonly bool _checkDuplicates;

        public List<string> ValidatedEmails { get; } = new List<string>();

        internal EmailValidator(IEnumerable<string> blacklistedEmails, IEnumerable<string> allowedDomains, bool checkDuplicates)
        {
            _blacklistedEmails = blacklistedEmails;
            _checkIsEmailBlacklisted = _blacklistedEmails != null ? true : false;

            _allowedDomains = allowedDomains;
            _checkIsDomainAllowed = _allowedDomains != null ? true : false;

            _checkDuplicates = checkDuplicates;
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

            if (_checkDuplicates && ValidatedEmails.Contains(email))
            {
                return false;
            }

            ValidatedEmails.Add(email);

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
