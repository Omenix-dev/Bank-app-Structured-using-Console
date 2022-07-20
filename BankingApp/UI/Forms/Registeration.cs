using BankingApp.Core.Contructs.Higher.Constants;
using BankingApp.Core.Contructs.Lower.IModel;
using BankingApp.Core;
using System.Collections;
using System;


namespace BankingApp.UI.Forms
{
    public class Registeration
    {
        internal static bool Forms(DIContainer Config)
        {
            Config.Validate();// instantiate the validation property
            Config.Print();// instantiate the Printer property
            Config.Update();// instantiate the updateandpreview property

            Console.Write("\nEnter your First name:");
            string firstName = Config.Validation.ValidateName(Console.ReadLine());

            Console.Write("\nEnter your Last name: ");
            string lastName = Config.Validation.ValidateName(Console.ReadLine());

            Console.Write("\nEnter your Email: ");
            string email = Config.Validation.ValidateEmail(Console.ReadLine());

            Console.Write("\nEnter your Age: ");
            int Age;
            while (true) {if(Int32.TryParse(Console.ReadLine(), out Age)) { break; } Config.Printer.Print("please enter a number");}

            Console.Write("\nChoose your Sex: \n");
            int Sex = Config.Validation.EnumConverters<SexType>();
            
            Console.Write("\nEnter your Occupation: ");
            string Occupation  = Config.Validation.IsRequired<string>(Console.ReadLine());

            Console.Write("\nEnter your Bank verification Number: ");
            string BVN =Config.Validation.IsRequired<string>(Console.ReadLine());

            Console.Write("\nChoose your Personal Identification type: \n");
            int IdType = Config.Validation.EnumConverters<IdType>();
            
            Console.Write("Choose your Personal Identification Number: ");
            string IdNO = Config.Validation.IsRequired<string>(Console.ReadLine());

            string Password;
            while (true) 
            {
                Console.Write("\nEnter you password: ");
                Password = Config.Validation.ValidatePassword(Console.ReadLine());
                Console.Write("\nRetype your password: ");
                string RetypePassword = Console.ReadLine();
                if (Password == RetypePassword) break;
                Config.Printer.Print("the password is not a match; PLease Retype the password");
            }

            ArrayList IsPassed = Config.UpdateAndPreview.Edit(IdNO,IdType, BVN, Occupation,Sex,Age,email,$"{firstName} {lastName}");
            var CreatingCustomer = Config.BankingSystem.RegisterCustomer(IsPassed[7].ToString(),
                                                                  (int)IsPassed[5],
                                                                  (SexType)IsPassed[4],
                                                                  (int)IsPassed[1],
                                                                  IsPassed[2].ToString(),
                                                                  IsPassed[0].ToString(),
                                                                  IsPassed[3].ToString(),
                                                                  Password,
                                                                  IsPassed[6].ToString(),
                                                                  Config.BankingSystem.Customers);
            
            if (CreatingCustomer.PersonalDetails != null)
            {
                return true;
            }
            else
            {
                return false;   
            }
        }
    }
}
