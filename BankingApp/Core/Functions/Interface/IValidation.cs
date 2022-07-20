using System;

namespace BankingApp.Core.Functions.Interface
{
    public interface IValidation
    {
        string ValidateName(string name);
        string ValidatePassword(string password);
        string ValidateEmail(string email);
        T IsRequired<T>(T value);
        int EnumConverters<T>() where T : System.Enum;
        decimal Amount();
    }
}
