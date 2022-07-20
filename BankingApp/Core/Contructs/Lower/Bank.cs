using System.Collections.Generic;
using BankingApp.Core.Contructs.Higher.Behaviours;
using BankingApp.Core.Contructs.Lower.IModel;


namespace BankingApp.Core.Contructs.Lower
{
    public class Bank : BankBehaviours, IBank
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
        private SecurityProtocol _Protocol;
        public SecurityProtocol Protocol { 
            get
            {
                return _Protocol;
            }
            set
            {
                _Protocol = value;
            }
        }

        public Bank(string BankName,List<Customers> 
                    customers, SecurityProtocol protocol)
        {
            Customers = customers;
            Protocol = protocol;
            this.BankName = BankName;
        }
        public Bank()
        {

        }
    }
}