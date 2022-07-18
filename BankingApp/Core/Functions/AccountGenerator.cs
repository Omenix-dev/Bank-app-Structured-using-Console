using System;
using System.Collections.Generic;

namespace BankingApp.Core.Functions
{
    public static class AccountGenerator
    {
        private static List<string> AccountHistory = new List<string>();
        public static string Generate()
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
