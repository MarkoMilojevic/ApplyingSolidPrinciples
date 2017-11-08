namespace SolidEmailValidation.Factories
{
    public interface ICreateEmailValidatorForTenant
    {
        string TenantName { get; }

        EmailValidator Create();
    }
}
