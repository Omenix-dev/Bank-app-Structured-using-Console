using BankingApp.Core.Contructs.Higher;


namespace BankingApp.Core.Functions.Interface
{
    public interface ICreateBankingRecord
    {
       ValidTransactionDetails Recorded(
                              string Description, string AccountNumber,
                              decimal Amount, int TransactionType, decimal balance)
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
