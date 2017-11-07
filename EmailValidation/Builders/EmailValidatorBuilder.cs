using System;
using System.Collections.Generic;
using System.Linq;

namespace EmailValidation.Builders
{

    public class EmailValidatorBuilder
    {
        private IEnumerable<string> _blacklistedEmails = Enumerable.Empty<string>();
        private bool _checkIsEmailBlacklisted = false;

        private IEnumerable<string> _allowedDomains = Enumerable.Empty<string>();
        private bool _checkIsDomainAllowed = false;

        private bool _checkDuplicates = false;

        public EmailValidatorBuilder ApplyBlacklistedEmailsValidation(IEnumerable<string> blacklistedEmails)
        {
            _blacklistedEmails = blacklistedEmails;
            _checkIsEmailBlacklisted = true;

            return this;
        }

        public EmailValidatorBuilder ApplyAllowedDomainsValidation(IEnumerable<string> allowedDomains)
        {
            _allowedDomains = allowedDomains;
            _checkIsDomainAllowed = true;

            return this;
        }

        public EmailValidatorBuilder ApplyDuplicatesValidation()
        {
            _checkDuplicates = true;

            return this;
        }

        public EmailValidator Build()
        {
            if (_checkIsEmailBlacklisted && _checkIsDomainAllowed && _checkDuplicates)
            {
                return new EmailValidator(_blacklistedEmails, _allowedDomains, _checkDuplicates);
            }
            else if (_checkIsEmailBlacklisted && _checkIsDomainAllowed)
            {
                return new EmailValidator(_blacklistedEmails, _allowedDomains);
            }
            else if (_checkIsEmailBlacklisted && _checkDuplicates)
            {
                return new EmailValidator(_blacklistedEmails, _checkDuplicates);
            }
            else if (_checkIsDomainAllowed && _checkDuplicates)
            {
                return new EmailValidator(_allowedDomains, _checkDuplicates);
            }
            else if (_checkIsEmailBlacklisted)
            {
                return new EmailValidator(_blacklistedEmails);
            }
            else if (_checkIsDomainAllowed)
            {
                return new EmailValidator(new string[] { }, _allowedDomains);
            }
            else if (_checkDuplicates)
            {
                return new EmailValidator(_checkDuplicates);
            }
            else
            {
                return new EmailValidator();
            }
        }
    }
}
