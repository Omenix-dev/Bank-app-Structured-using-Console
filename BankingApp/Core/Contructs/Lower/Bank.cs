using System.Collections.Generic;
using BankingApp.Core.Contructs.Higher.Behaviours;

namespace BankingApp.Core.Contructs.Lower
{

    public class Bank : BankBehaviours
    {
        private string _BankName;

        public string BankName
        {
            get { return _BankName; }
            set { _BankName = value; }
        }
        private List<Customers> _Customers;
        public List<Customers> Customers
        {
            get { return _Customers; }
            set { _Customers = value; }
        }

        // this is the object that holds the policies guarding the bank
        internal SecurityProtocol Protocol;
        private decimal _TotalMoneyInBank;
        public decimal TotalMoneyInBank
        {
            get { return _TotalMoneyInBank; }
            set { _TotalMoneyInBank = value; }
        }

        public Bank(string BankName,List<Customers> 
                    customers, SecurityProtocol protocol, 
                    decimal totalMoneyInBank)
        {
            Customers = customers;
            TotalMoneyInBank = totalMoneyInBank;
            Protocol = protocol;
            this.BankName = BankName;
        }
        
    }
}
