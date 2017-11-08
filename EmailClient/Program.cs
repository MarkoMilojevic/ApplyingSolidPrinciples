using EmailValidation.Builders;
using System;
using System.Collections.Generic;

namespace EmailClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var email = "user@test.com";
            var blacklistedEmails = new List<string> { "bot@spam.com" };
            var allowedDomains = new List<string> { "test.com" };

            var validator = new EmailValidatorBuilder()
                                .ApplyBlacklistedEmailsValidation(blacklistedEmails)
                                .ApplyAllowedDomainsValidation(allowedDomains)
                                .ApplyDuplicatesValidation()
                                .Build();

            var result = validator.IsValid(email) ? "Valid" : "Invalid";

            Console.WriteLine($"{result} - {email}");
            Console.ReadKey();
        }
    }
}
