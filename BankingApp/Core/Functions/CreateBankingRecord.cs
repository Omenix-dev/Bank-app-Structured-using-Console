using System;
using BankingApp.Core.Contructs.Higher;

namespace BankingApp.Core.Functions
{
    public static class CreateBankingRecord
    {
        public static ValidTransactionDetails Recorded(
                              string Description, string AccountNumber,
                              Decimal Amount, int TransactionType,decimal balance)
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
