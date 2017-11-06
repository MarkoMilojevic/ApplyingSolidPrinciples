using EmailValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var email = "user@test.com";
            var validator = new EmailValidator();

            var result = validator.IsValid(email) ? "Valid" : "Invalid";

            Console.WriteLine($"{result} - {email}");
            Console.ReadKey();
        }
    }
}
