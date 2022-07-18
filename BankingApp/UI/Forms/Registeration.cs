using BankingApp.Core.Contructs.Higher.Constants;
using BankingApp.Core.Functions;
using BankingApp.Core.Contructs.Lower;
using System.Collections;
using System;
using System.Reflection;


namespace BankingApp.UI.Forms
{
    public class Registeration
    {
        internal static bool Forms(Bank BankingSystem)
        {
            Console.Write("\nEnter your First name:");
            string firstName = Validation.ValidateName(Console.ReadLine());

            Console.Write("\nEnter your Last name: ");
            string lastName = Validation.ValidateName(Console.ReadLine());

            Console.Write("\nEnter your Email: ");
            string email = Validation.ValidateEmail(Console.ReadLine());

            Console.Write("\nEnter your Age: ");
            int Age;
            while (true) {if(Int32.TryParse(Console.ReadLine(), out Age)) { break; } Printer.Print("please enter a number");}

            Console.Write("\nChoose your Sex: \n");
            int Sex = Validation.EnumConverters<SexType>();
            
            Console.Write("\nEnter your Occupation: ");
            string Occupation  = Validation.IsRequired<string>(Console.ReadLine());

            Console.Write("\nEnter your Bank verification Number: ");
            string BVN =Validation.IsRequired<string>(Console.ReadLine());

            Console.Write("\nChoose your Personal Identification type: \n");
            int IdType = Validation.EnumConverters<IdType>();
            
            Console.Write("Choose your Personal Identification Number: ");
            string IdNO = Validation.IsRequired<string>(Console.ReadLine());

            string Password;
            while (true) 
            {
                Console.Write("\nEnter you password: ");
                Password = Validation.ValidatePassword(Console.ReadLine());
                Console.Write("\nRetype your password: ");
                string RetypePassword = Console.ReadLine();
                if (Password == RetypePassword) break;
                Printer.Print("the password is not a match; PLease Retype the password");
            }

            ArrayList IsPassed = UpdateAndPreview.Edit(IdNO,IdType, BVN, Occupation,Sex,Age,email,$"{firstName} {lastName}");
            var CreatingCustomer = BankingSystem.RegisterCustomer(IsPassed[7].ToString(),
                                                                  (int)IsPassed[5],
                                                                  (SexType)IsPassed[4],
                                                                  (int)IsPassed[1],
                                                                  IsPassed[2].ToString(),
                                                                  IsPassed[0].ToString(),
                                                                  IsPassed[3].ToString(),
                                                                  Password,
                                                                  IsPassed[6].ToString(),
                                                                  BankingSystem.Customers);
            
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
