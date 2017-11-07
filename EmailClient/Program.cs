using EmailValidation.Builders;
using System;

namespace EmailClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var email = "user@test.com";
            var validator = new EmailValidatorBuilder().Build();

            var result = validator.IsValid(email) ? "Valid" : "Invalid";

            Console.WriteLine($"{result} - {email}");
            Console.ReadKey();
        }
    }
}
