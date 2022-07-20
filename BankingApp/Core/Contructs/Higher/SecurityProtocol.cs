using System;
using System.Collections.Generic;
using BankingApp.Core.Contructs.Higher.Constants;
using BankingApp.Core.Contructs.Higher;
using System.Linq;
using BankingApp.Core.Contructs.Lower.IModel;

namespace BankingApp.Core.Contructs.Lower
{
    public class SecurityProtocol : ISecurityProtocol
    {
        // contains the value that's presently logged into the value
        //this container is used tio hold the customer for the session until he logs out
        private Customers _SESSION;
        public Customers SESSION
        {
            get { return _SESSION; }
            set { _SESSION = value; }
        }

        // this is the variable that is used to store the present logging state
        private bool _IsLogged = false;
        public bool IsLogged
        {
            get { return _IsLogged; }
            set { _IsLogged = value; }
        }
        public bool IsValid(decimal Deposit, AccountType AccountType)
        {
            if (_IsLogged)
            {
                var Account = (int)AccountType == 1 ? Policy.CurLeast : Policy.SavLeast;
                if (Deposit >= Convert.ToDecimal((int)Account))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsAuthenticated(string Email,string Password, List<Customers>AllCustomer) 
        {
            foreach (Customers item in AllCustomer)
            {
                if (item.Password == Password.ToLower() && 
                    item.PersonalDetails.Email.ToLower() == Email.ToLower())
                {
                    SESSION = item;
                    IsLogged = true;
                    return true;
                }
            }
            return false;
        }
        public AccountDetails IsAValidAccount(string AccountNumber,List<Customers>AllCustomer)
        {
            foreach (var Customer in AllCustomer)
            {
                // where linq statement
                var value = from Number in Customer.CustomerAccountDetails
                            where Number.AccountNumber.Contains(AccountNumber)
                            select Number;
                if (value.Count() > 0)
                    foreach (var item in value) { return item; }
            }
            
            return null;
        }

        public AccountDetails CheckAccountability(decimal Withdrawal, string AccountNumber)
        {
            // system where linq
            var value = from Number in SESSION.CustomerAccountDetails
                        where Number.AccountNumber.Contains(AccountNumber)
                        select Number;
            AccountDetails container = null;
            // this is used to unpack the list into the container
            foreach(var item in value){container = item;}
            if(container != null)
            {
                if(container.Balance-Withdrawal > ((int)container.AccountType == 0 ? (int)Policy.SavLeast: (int)Policy.CurLeast))
                return container;
                
                return null;
            }
             return null;
        }
        
    }
}

