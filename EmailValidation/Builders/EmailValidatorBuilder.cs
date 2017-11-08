using System.Collections.Generic;

namespace EmailValidation.Builders
{

    public class EmailValidatorBuilder
    {
        private IEnumerable<string> _blacklistedEmails = null;
        private IEnumerable<string> _allowedDomains = null;
        private bool _checkDuplicates = false;

        public EmailValidatorBuilder ApplyBlacklistedEmailsValidation(IEnumerable<string> blacklistedEmails)
        {
            _blacklistedEmails = blacklistedEmails ?? throw new System.ArgumentNullException(nameof(blacklistedEmails));

            return this;
        }

        public EmailValidatorBuilder ApplyAllowedDomainsValidation(IEnumerable<string> allowedDomains)
        {
            _allowedDomains = allowedDomains ?? throw new System.ArgumentNullException(nameof(allowedDomains));

            return this;
        }

        public EmailValidatorBuilder ApplyDuplicatesValidation()
        {
            _checkDuplicates = true;

            return this;
        }

        public EmailValidator Build()
        {
            return new EmailValidator(_blacklistedEmails, _allowedDomains, _checkDuplicates);
        }
    }
}
