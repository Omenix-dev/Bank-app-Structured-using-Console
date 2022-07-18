using System;
using BankingApp.Core.Contructs.Higher.Constants;

namespace BankingApp.Core.Contructs.Higher
{
    public class ValidTransactionDetails
    {
        private decimal _balance;

        public decimal balance
        {
            get { return _balance; }
            private set { _balance = value; }
        }

        private AccountType _AccountType;

        public AccountType accountType   
        {
            get { return _AccountType; }
            set { _AccountType = value; }
        }
        private string _AccountNumber;

        public string AccountNumber
        {
            get { return _AccountNumber; }
            set { _AccountNumber = value; }
        }


        private DateTime _DateOfTransaction;
        public DateTime DateOfTransaction
        {
            get { return _DateOfTransaction; }
            set { _DateOfTransaction = value; }
        }

        private string _TransactionDesc;
        public string TransactionDesc
        {
            get { return _TransactionDesc; }
            set { _TransactionDesc = value; }
        }

        private decimal _Amount;

        public decimal TransactionAmount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        private int _TransactionType;
        public int TransactionType
        {
            get { return _TransactionType; }
            set { _TransactionType = value; }
        }

        public ValidTransactionDetails(string Description,
                                      string AccountNumber,
                                      Decimal Amount, 
                                      int TransactionType,
                                      decimal balance)
        {
            this.DateOfTransaction = DateTime.Now;
            this.TransactionDesc = Description;
            this.AccountNumber = AccountNumber;
            this.TransactionAmount = Amount;
            this.TransactionType = TransactionType;
            this.balance = balance + (TransactionType * Amount);
        }
    }
}
