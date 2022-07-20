using BankingApp.Core.Contructs.Lower;
using BankingApp.Core.Contructs.Higher.Constants;
using System.Collections.Generic;
using BankingApp.Core.Contructs.Higher.Behaviours.IBehaviours;

namespace BankingApp.Core.Contructs.Higher.Behaviours
{
    public class BankBehaviours
    {
        DIContainer Config = new DIContainer();

        public bool Withdrawal(SecurityProtocol Protocol,
                               string Description,
                               decimal Deposit,
                               string AccountNumber) 
        {
            Config.Record();
            if (Protocol.IsLogged)
            {
                var CanWithdraw = Protocol.CheckAccountability(Deposit, AccountNumber);
                if (CanWithdraw != null)
                {
                // created the record once the value is the withdrawal is authorised
                   var CreateRecord = Config.CreateBankingRecord.Recorded
                                       (Description, AccountNumber,
                                       Deposit, -1,CanWithdraw.Balance);
                    CanWithdraw.ValidTransactionDetails.Add(CreateRecord);
                    return true;// withdrawal is successful
                }
                return false;// if the person has in sufficient balance
            }
            return false;// if the person is not logged in 
        }// end of the withdrawal method

        public bool AcceptDeposit(decimal Deposit,string AccountNumber,string Description,
                                  SecurityProtocol Protocol,List<Customers>AllCustomers)
        {
            Config.Record();
            // this is used to check whether the Account has been created
            var IsExiting = Protocol.IsAValidAccount(AccountNumber,AllCustomers);
            if (IsExiting != null)
            {
                var CreateRecord = Config.CreateBankingRecord.Recorded(Description,
                                                                AccountNumber,
                                                                Deposit,1,
                                                                IsExiting.Balance);

                IsExiting.ValidTransactionDetails.Add(CreateRecord);
                return true;
            }
            return false;
        }

        public bool Transfer(SecurityProtocol Protocol,
                             string Description,
                             string SenderAccountNO,
                             string RecipientAccountNO,
                             List<Customers> AllCustomers,
                             decimal Amount)
        {
            if (Protocol.IsLogged)
            {
                //when logging in first deduct from the sender
                var ISuccessfull = Withdrawal(Protocol,
                                              Description,
                                              Amount,
                                              SenderAccountNO);
                if (ISuccessfull)
                {
                    //then is the process that is used to transfer money
                    var IsTranfered = AcceptDeposit(Amount,
                                                    RecipientAccountNO,
                                                    Description,
                                                    Protocol,
                                                    AllCustomers);
                    if (IsTranfered) 
                    {
                        return IsTranfered;
                    }
                    else
                    {
                        // since this has already been transfered you
                        // have to re credit the already transfered funds
                        var ReFundSender = AcceptDeposit(Amount,
                                                        SenderAccountNO,
                                                        "Refunding money",
                                                        Protocol,
                                                        AllCustomers);   
                    }
                }
                return false;// couldn't
            }
            return false;// this would return if the customer has not logged in
        }

        public bool LoginCustomer(string Email,string Password,
                                  List<Customers> AllCustomers,
                                  SecurityProtocol ProtocolValdator)
        {
            // get the details from the the user about his present state
            var ValidCustomer = ProtocolValdator.IsAuthenticated(Email, Password, AllCustomers);
            return ValidCustomer;
        }

        public bool CreateAccount(int AccountType,decimal Deposit,SecurityProtocol Protocol) 
        {
            Config.Record();
            if (Protocol.IsLogged)
            {
                if (Protocol.IsValid(Deposit,(AccountType)AccountType))
                {
                    //instantiated the customer accout details below
                    var AccountCreatedInformation = new AccountDetails((AccountType)AccountType, Deposit);
                    var CreateRecord = Config.CreateBankingRecord.Recorded("Account was Created",
                                       AccountCreatedInformation.AccountNumber,Deposit,1,0.0M);

                    AccountCreatedInformation.ValidTransactionDetails.Add(CreateRecord);// update the list with transcation details
                    Protocol.SESSION.CustomerAccountDetails.Add(AccountCreatedInformation);// add the list account details to the customer account details created
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


        public void PrintStatement(SecurityProtocol Protocol,string AccountNumber)
        {
            Config.PrintCus();
            if (Protocol.IsLogged)
            {
                var AccountIsValid = Protocol.IsAValidAccount(AccountNumber,
                                    new List<Customers>(){Protocol.SESSION});

                if (AccountIsValid != null)
                {
                    Config.PrintCustomer.TransactionDetails(AccountIsValid.ValidTransactionDetails);                    
                }
            }
        }

        public Customers RegisterCustomer(string fullname, int age, SexType sex,
                                    int idtype, string bvn, string IdNO,string occupation,
                                    string Password,string email, List<Customers> CustomersCollection)
        {
            // get the personal details for the customer
            var item = new Customers(fullname,age,sex,(IdType)idtype,bvn,IdNO,occupation,Password,email);
            CustomersCollection.Add(item);
            return item;
        }
    }
}
