using BankingApp.Core.Contructs.Higher.Constants;
using BankingApp.Core.Functions;
using System.Collections.Generic;
using System.Linq;

namespace BankingApp.Core.Contructs.Higher
{
    public class AccountDetails
    {
        private AccountType _AccountType;
        public AccountType AccountType
        {
            get { return _AccountType; }
            set { _AccountType = value; }
        }

        public decimal Balance
        {
            get {
                // here the getter wuould loop through the
                // valid transaction to get the available balance
                var balance = from x in ValidTransactionDetails
                              select x.TransactionAmount * x.TransactionType;

                    return balance.Sum(); 
                }
        }

        private List<ValidTransactionDetails> _ValidTransactionDetails;
        public List<ValidTransactionDetails> ValidTransactionDetails
        {
            get { return _ValidTransactionDetails; }
            set { _ValidTransactionDetails = value; }
        }

        private string _AccountNumber;
        public string AccountNumber
        {
            get { return _AccountNumber; }
            private set 
            {
                _AccountNumber = value;
            }
        }
        //public AccountDetails() { }
        public AccountDetails(AccountType AccountType, decimal Deposit)
        {
            var Config = new DIContainer();
            Config.Account();
            this.AccountType = AccountType;
            AccountNumber = Config.AccountGenerator.Generate();
            ValidTransactionDetails = new List<ValidTransactionDetails>();
        }
    }
}
