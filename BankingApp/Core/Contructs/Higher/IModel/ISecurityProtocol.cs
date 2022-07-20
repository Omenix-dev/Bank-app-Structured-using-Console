using System.Collections.Generic;
using BankingApp.Core.Contructs.Higher.Constants;
using BankingApp.Core.Contructs.Higher;

namespace BankingApp.Core.Contructs.Lower.IModel
{
    public interface ISecurityProtocol
    {
        Customers SESSION { get; set; }
        bool IsLogged { get; set; }
        bool IsValid(decimal Deposit, AccountType AccountType);
        AccountDetails IsAValidAccount(string AccountNumber, List<Customers> AllCustomer);
        AccountDetails CheckAccountability(decimal Withdrawal, string AccountNumber);
        bool IsAuthenticated(string Email, string Password, List<Customers> AllCustomer);
    }
}
