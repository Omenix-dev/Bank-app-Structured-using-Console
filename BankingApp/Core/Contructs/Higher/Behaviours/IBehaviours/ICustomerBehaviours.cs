using BankingApp.Core.Contructs.Lower.IModel;

namespace BankingApp.Core.Contructs.Higher.Behaviours.IBehaviours
{
    public interface ICustomerBehaviours
    {
        bool Deposit(IBank BankingSystem, decimal Deposit,
                    string AccountNumber, string Description);
        bool WithdrawalRequest(IBank BankingSystem, decimal Deposit,
                   string AccountNumber, string Description);
        bool TransferRequest(IBank BankingSystem,
                                    decimal Deposit,
                                    string SenderAccountNo,
                                    string RecipientAccountNo,
                                    string Description);
        void Logout(IBank BankingSystem);

        void RequestStatement(IBank BankingSystem, string AccountNumber);
    }
}
