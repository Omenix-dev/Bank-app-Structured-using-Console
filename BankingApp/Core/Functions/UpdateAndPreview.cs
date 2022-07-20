using BankingApp.Core.Contructs.Higher.Constants;
using System.Collections.Generic;
using System.Collections;
using System;
using BankingApp.Core.Functions.Interface;

namespace BankingApp.Core.Functions
{
    internal class UpdateAndPreview : IUpdateAndPreview
    {
        DIContainer Config = new DIContainer();// DI Container 
        public ArrayList Edit(
                                  string IdNO, int IdType, string BVN,
                                  string Occupation, int Sex,
                                  int Age, string email,
                                  string fullname)
        {
            while (true)
            {
                Config.Print();// initializes only printer property
                Config.Validate();// initialize only the validation property
                Console.Clear();
                List<string> headerValues = new List<string> { "1. fullname", "2. email", "3. BVN", "4. IDtype", "5. IdNO", "6. Occupation", "7. Sex", "8. Age" };
                List<string[]> footerValues = new List<string[]>()
                    {
                        new string[] { fullname, email,
                                       BVN, ((IdType)IdType).ToString(),
                                       IdNO, Occupation, ((SexType)Sex).ToString(),
                                       Age.ToString() }
                    };
                Config.Printer.printTable(footerValues,headerValues);
                
                Config.Printer.Print("Do you want to Change any information Press U for updating or Press C to Continue",true);

                var Keyvalue = Console.ReadKey();
                if (Keyvalue.Key == ConsoleKey.U)
                {
                    Console.WriteLine("\nEnter the serial number you wish to update");
                    int value;
                    while (!Int32.TryParse(Console.ReadLine(), out value) && (value < 9 || value > 0))
                    {
                        Config.Printer.Print("Enter a number within the accepted range");
                    }
                    switch (value)
                    {
                        case 1:
                            Console.WriteLine("enter full name");
                            fullname = Config.Validation.ValidateName(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("enter email");
                            email = Config.Validation.ValidateEmail(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("enter BVN number");
                            BVN = Config.Validation.IsRequired<string>(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Enter the type of indentification");
                            IdType = Config.Validation.EnumConverters<IdType>();
                            break;
                        case 5:
                            Console.WriteLine("Enter Id Number");
                            IdNO = Config.Validation.IsRequired<string>(Console.ReadLine());
                            break;
                        case 6:
                            Console.WriteLine("Enter Occupation");
                            Occupation = Config.Validation.IsRequired<string>(Console.ReadLine());
                            break;
                        case 7:
                            Console.WriteLine("enter Sex: ");
                            Sex = Config.Validation.EnumConverters<SexType>();
                            break;
                        case 8:
                            Console.WriteLine("Age: ");
                            while (true) { if (Int32.TryParse(Console.ReadLine(), out Age)) { break; } Config.Printer.Print("please enter a number"); }
                            break;
                    }
                }
                else if (Keyvalue.Key == ConsoleKey.C)
                {
                    return new ArrayList() { IdNO, IdType, BVN, Occupation, Sex, Age, email, fullname };
                }
                
            }
        }
    }
}
