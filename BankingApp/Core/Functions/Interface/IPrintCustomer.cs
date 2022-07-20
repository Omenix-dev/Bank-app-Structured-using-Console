using BankingApp.Core.Contructs.Lower;
using System.Collections.Generic;
using BankingApp.Core.Contructs.Higher;

namespace BankingApp.Core.Functions.Interface
{
    public interface IPrintCustomer
    {
         void AccountDetails(Customers Member);
         void TransactionDetails(List<ValidTransactionDetails> Member);
        
    }
}
