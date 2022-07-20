using BankingApp.Core.Functions;
using BankingApp.Core.Functions.Interface;
using BankingApp.Core.Contructs.Higher.Behaviours.IBehaviours;
using BankingApp.Core.Contructs.Lower;
using BankingApp.Core.Contructs.Lower.IModel;
using System.Collections.Generic;

namespace BankingApp.Core
{
    public class DIContainer
    {
        public IAccountGenerator AccountGenerator { get; set; }
        public ICreateBankingRecord CreateBankingRecord { get; set; }
        public IJustification Justification { get; set; }
        public IPrintCustomer PrintCustomer { get; set; }
        public IPrinter Printer { get; set; }
        public IUpdateAndPreview UpdateAndPreview {get; set;}
        public IValidation Validation { get; set; }
        public IBank BankingSystem { get; set; }
        
        public ISecurityProtocol Protocol { get; set; }

        public void Security()
        {
            ISecurityProtocol _Protocol = new SecurityProtocol();
            Protocol = _Protocol;
        }
        public void Banking(string BankName, List<Customers>
                            customers, SecurityProtocol protocol)
        {
            IBank _BankingSystem = new Bank(BankName, customers, protocol);
            BankingSystem = _BankingSystem;
            //return BankingSygtem
        }
        public void Account()
        {
            IAccountGenerator _AccountGenerator = new AccountGenerator();
            AccountGenerator = _AccountGenerator;   
        }
        public void Record()
        {
            ICreateBankingRecord _CreateBankingRecord = new CreateBankingRecord();
            CreateBankingRecord = _CreateBankingRecord;
        }
        public void Justify()
        {
            IJustification _Justification =  new Justification();
            Justification = _Justification;
        }
        public void Print()
        {
            IPrinter _Printer = new Printer();
            Printer = _Printer;
        }
        public void PrintCus()
        {
            IPrintCustomer _PrintCustomer = new PrintCustomer();
            PrintCustomer = _PrintCustomer;
        }
        public void Update()
        {
            IUpdateAndPreview _UpdateAndPreview = new UpdateAndPreview();
            UpdateAndPreview = _UpdateAndPreview;   
        }
        public void Validate()
        {
            IValidation _Validation = new Validation();
            Validation = _Validation;                   
        }
        
    }
}
