using System;
using System.Collections.Generic;
using BankingApp.Core.Functions.Interface;

namespace BankingApp.Core.Functions
{
    public class AccountGenerator : IAccountGenerator 
    {
        private List<string> AccountHistory = new List<string>();
        public string Generate()
        {
            var accountNumber = "";
            while (true)
            {
                string AccountNumberGenerator = "0000000000";
                var Random = new Random();
                int NumberGenerated = Random.Next(0, 10000);
                int len = NumberGenerated.ToString().Length;
                accountNumber = $"{AccountNumberGenerator.Substring(0, 10-len)}{NumberGenerated.ToString()}";
                if (AccountHistory.Contains(accountNumber))
                {
                    continue;
                }
                else
                {
                    break;
                }
                    
            }
            AccountHistory.Add(accountNumber);
            return accountNumber;
        }
    }
}
