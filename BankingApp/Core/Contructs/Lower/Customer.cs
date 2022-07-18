using BankingApp.Core.Contructs.Higher;
using BankingApp.Core.Contructs.Higher.Behaviours;
using BankingApp.Core.Contructs.Higher.Constants;
using System.Collections.Generic;

namespace BankingApp.Core.Contructs.Lower
{
    public class Customers : CustomerBehaviours
    {
        private List<AccountDetails> _CustomerAccountDetails;
        public List<AccountDetails> CustomerAccountDetails
        {
            get { return _CustomerAccountDetails; }
            private set { _CustomerAccountDetails = value; }
        }

        private PersonalDetails _PersonalDetails;
        public PersonalDetails PersonalDetails
        {
            get { return _PersonalDetails; }
            protected set { _PersonalDetails = value; }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            private set { _Password = value; }
        }

        public Customers(string fullname, int age, SexType sex,IdType id,
                         string bvn, string IdNO, string occupation,string Password,string email)
        {
            // creates the objects for the personal details with the details from the forms
            PersonalDetails = new PersonalDetails(fullname,age,sex,id,bvn,IdNO,occupation,email);
            this.Password = Password;// this is used to store the password 

            // initializes a pointer values for the object CustomerAccountDetails to store the locations
            this.CustomerAccountDetails = new List<AccountDetails>();
        }
        


    }
}
