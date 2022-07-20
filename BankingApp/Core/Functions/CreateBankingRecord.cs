using System;
using BankingApp.Core.Contructs.Higher;
using BankingApp.Core.Functions.Interface;

namespace BankingApp.Core.Functions
{
    public class CreateBankingRecord : ICreateBankingRecord
    {
        public ValidTransactionDetails Recorded(
                              string Description, string AccountNumber,
                              decimal Amount, int TransactionType,decimal balance)
        {
            var Details = new ValidTransactionDetails(Description,
                                                      AccountNumber,
                                                      Amount,
                                                      TransactionType,
                                                      balance);
            return Details;
        }
    }
}
