using BankingApp.Core.Contructs.Lower;
using System;

namespace BankingApp.Core.Contructs.Higher.Behaviours
{
    public class CustomerBehaviours
    {
       public bool Deposit(Bank BankingSystem, decimal Deposit, 
                    string AccountNumber, string Description )
        {
            bool val = BankingSystem.AcceptDeposit(Deposit, 
                                        AccountNumber,
                                        Description,
                                        BankingSystem.Protocol,
                                        BankingSystem.Customers);
            if(val)return true;
            return false;
        }

       public bool WithdrawalRequest(Bank BankingSystem, decimal Deposit, 
                   string AccountNumber, string Description)
        {
            bool value = BankingSystem.Withdrawal(BankingSystem.Protocol,
                                    Description, Deposit, AccountNumber);

            if (value) return true;
            else return false;
        }

        public bool TransferRequest (Bank BankingSystem,
                                    decimal Deposit, 
                                    string SenderAccountNo, 
                                    string RecipientAccountNo,
                                    string Description) 
        {
            bool value = BankingSystem.Transfer(BankingSystem.Protocol, 
                                   Description,SenderAccountNo,
                                   RecipientAccountNo,BankingSystem.Customers,
                                   Deposit);
            if(value)return true;
            else return false;
        }

       public void Logout(Bank BankingSystem) 
        {
            BankingSystem.Protocol.SESSION = null;// this empty the container there by ending the session
            BankingSystem.Protocol.IsLogged = false;// this add the restriction that initializes customer logout 
        }

       public void RequestStatement(Bank BankingSystem,string AccountNumber) 
        {
            BankingSystem.PrintStatement(BankingSystem.Protocol, AccountNumber);
        }
    }
}
