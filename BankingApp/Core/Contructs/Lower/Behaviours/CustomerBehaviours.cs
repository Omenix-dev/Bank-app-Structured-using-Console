using BankingApp.Core.Contructs.Lower.IModel;
using BankingApp.Core.Contructs.Higher.Behaviours.IBehaviours;

namespace BankingApp.Core.Contructs.Higher.Behaviours
{
    public class CustomerBehaviours: ICustomerBehaviours
    {
       public bool Deposit(IBank BankingSystem, decimal Deposit, 
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
        
       public bool WithdrawalRequest(IBank BankingSystem, decimal Deposit, 
                   string AccountNumber, string Description)
        {
            bool value = BankingSystem.Withdrawal(BankingSystem.Protocol,
                                    Description, Deposit, AccountNumber);

            if (value) return true;
            else return false;
        }

       public bool TransferRequest (IBank BankingSystem,
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

       public void Logout(IBank BankingSystem) 
        {
            BankingSystem.Protocol.SESSION = null;// this empty the container there by ending the session
            BankingSystem.Protocol.IsLogged = false;// this add the restriction that initializes customer logout 
        }

       public void RequestStatement(IBank BankingSystem,string AccountNumber) 
        {
            BankingSystem.PrintStatement(BankingSystem.Protocol, AccountNumber);
        }
    }
}
