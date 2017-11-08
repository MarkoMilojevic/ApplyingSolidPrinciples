using SolidEmailValidation.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SolidEmailValidation.Factories
{
    public static class EmailValidatorFactory
    {
        private static readonly Dictionary<string, ICreateEmailValidatorForTenant> _factoriesByTenants;

        static EmailValidatorFactory()
        {
            var thisNamespace = typeof(EmailValidatorFactory).Namespace;

            var factoryTypes = Assembly
                                .GetExecutingAssembly()
                                .GetTypes()
                                .Where(type => type.Namespace == thisNamespace
                                            && typeof(ICreateEmailValidatorForTenant).IsAssignableFrom(type)
                                            && type.IsClass);

            foreach (var type in factoryTypes)
            {
                var factory = (ICreateEmailValidatorForTenant)Activator.CreateInstance(type);

                _factoriesByTenants[factory.TenantName] = factory;
            }
        }

        public static EmailValidator CreateFor(string tenantName)
        {
            if (_factoriesByTenants.TryGetValue(tenantName, out var factory))
            {
                return factory.Create();
            }

            return CreateAlwaysValidEmailValidator();
        }

        private static EmailValidator CreateAlwaysValidEmailValidator()
        {
            return new EmailValidator(new AlwaysValidRule());
        }
    }
}
