using BankingApp.Core.Contructs.Lower;
using System.Collections.Generic;
using BankingApp.Core.Contructs.Higher;
using System;
using BankingApp.Core.Functions.Interface;


namespace BankingApp.Core.Functions
{
    public class PrintCustomer : IPrintCustomer
    {
       
        DIContainer DIConfig = new DIContainer();// DI container;
        public void AccountDetails(Customers Member)
        {
            DIConfig.Print();
            List<string> headerValues = new List<string> { "S/N","          Name          ", "Account number",
                                                       "Account Type", "Acccount Balance" };
            int i = 1;
            var footerValues = new List<string[]>();
            foreach (var item in Member.CustomerAccountDetails)
            {
                footerValues.Add(new string[] { i.ToString(),Member.PersonalDetails.Name,
                                               item.AccountNumber, item.AccountType.ToString(),
                                               $"#{item.Balance.ToString("#.00")}K"});
                i++;
            }
            DIConfig.Printer.printTable(footerValues,headerValues);
        }

        public void TransactionDetails(List<ValidTransactionDetails> Member)
        {
            DIConfig.Print();
            List<string> headerValues = new List<string> { "Date", "          Account description          ", 
                                                "Amount", "Acccount Balance" };
            int i = 1;
            var footerValues = new List<string[]>();


            foreach (var item in Member)
            {
                footerValues.Add(new string[] {String.Format("{0:MM/dd/yyyy}",item.DateOfTransaction),item.TransactionDesc,
                                                $"#{item.TransactionAmount.ToString("#.00")}K",
                                                    $"#{item.balance.ToString("#.00")}K"});
                i++;
            }
            DIConfig.Printer.printTable(footerValues, headerValues);
        }
    }
}
