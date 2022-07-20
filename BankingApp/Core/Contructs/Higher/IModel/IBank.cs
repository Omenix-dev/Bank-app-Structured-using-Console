using System.Collections.Generic;
using BankingApp.Core.Contructs.Higher.Constants;


namespace BankingApp.Core.Contructs.Lower.IModel
{
    public interface IBank
    {
        string BankName { get; set; }
        List<Customers> Customers { get; set; }
        SecurityProtocol Protocol { get; set; }
        bool Withdrawal(SecurityProtocol Protocol,
                        string Description,
                        decimal Deposit,
                        string AccountNumber);
        bool AcceptDeposit(decimal Deposit, string AccountNumber,
                            string Description,
                            SecurityProtocol Protocol,
                            List<Customers> AllCustomers);

        bool Transfer(SecurityProtocol Protocol,
                        string Description,
                        string SenderAccountNO,
                        string RecipientAccountNO,
                        List<Customers> AllCustomers,
                        decimal Amount);
        bool LoginCustomer(string Email, string Password,
                            List<Customers> AllCustomers,
                            SecurityProtocol ProtocolValdator);
        bool CreateAccount(int AccountType, decimal Deposit,
                            SecurityProtocol Protocol);
        void PrintStatement(SecurityProtocol Protocol,
                            string AccountNumber);
        Customers RegisterCustomer(string fullname, int age, SexType sex,
                                    int idtype, string bvn, string IdNO, string occupation,
                                    string Password, string email,
                                    List<Customers> CustomersCollection);
    }
}
