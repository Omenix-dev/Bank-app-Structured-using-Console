using System;
using System.Collections.Generic;
using BankingApp.UI.Forms;
using BankingApp.Core;

namespace BankingApp.UI.Interaction
{
    public class Welcome
    {
        public static void Show(DIContainer Config)
        {
            //ultimate Looper that prevents the loop from ending
            while (true)
            {
                Config.Validate();// instantiate the validation property
                Config.Print();// instantiate the Config.Printer property

                Console.WriteLine($"<==============================================Welcome to {Config.BankingSystem.BankName} ============================================>");

                Console.WriteLine("\n<=============Press the Serial number representing the prefered banking services you want to perform=============>");
                // display banking services
                List<string> headerValues = new List<string> {"S/N","Banking Services","Restriction"};
                List<string[]> footerValues = new List<string[]>
                {
                    new string[] {"1","Register","Everybody"},
                    new string[] {"2","Create Account","All Customers"},
                    new string[] {"3","Deposit Money","Everybody"},
                    new string[] {"4","Login","only Registered"},
                    new string[] {"5","Exit Application","Everybody"},
                };
                Config.Printer.printTable(footerValues,headerValues);
                
                ConsoleKeyInfo Keyvalue = Console.ReadKey();
                if(Keyvalue.Key == ConsoleKey.NumPad1 || Keyvalue.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    bool Message = Registeration.Forms(Config);
                    if (Message) 
                    {
                        Console.Clear();
                        Config.Printer.Print("\nYou have Successfully been Registered",true);
                    }
                    else
                    {
                        Console.Clear();
                        Config.Printer.Print("\nthe registration was not successful");
                    }
                    continue;
                }
                else if(Keyvalue.Key == ConsoleKey.NumPad2 || Keyvalue.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Config.Printer.Print("You are not yet Logged in and therefore can not perform a Create Account Action");
                }
                else if (Keyvalue.Key == ConsoleKey.NumPad3 || Keyvalue.Key == ConsoleKey.D3)
                {
                    
                    Console.Clear();
                    Console.WriteLine("Enter the amount you wish to deposit");
                    decimal amount = Config.Validation.Amount();

                    Console.WriteLine("Enter Recipient Account Number");
                    string accountNumber = Console.ReadLine();

                    Console.WriteLine("Enter reason for deposit");
                    string desc = Config.Validation.IsRequired<string>(Console.ReadLine());
                    bool value = Config.BankingSystem.AcceptDeposit(amount, accountNumber,
                                desc,Config.BankingSystem.Protocol,Config.BankingSystem.Customers);

                    Console.Clear();
                    if (value) Config.Printer.Print("Transaction Successfull", true);
                    else Config.Printer.Print("Transaction UNSuccessfull", false);
                    // implement the Deposit face for unlogged users
                }
                else if (Keyvalue.Key == ConsoleKey.NumPad4 || Keyvalue.Key == ConsoleKey.D4)
                {
                    //get the login passwword and fullName
                    Console.Clear();
                    Console.Write("\nEnter your Email: ");
                    string Email = Console.ReadLine();

                    Console.Write("\nEnter the password: ");
                    string password = Console.ReadLine();
                    bool IsValid = Config.BankingSystem.LoginCustomer(Email,password,Config.BankingSystem.Customers,Config.BankingSystem.Protocol);
                    if (IsValid)
                    {
                        Console.Clear();
                        CustomerAction.Service(Config);
                    }
                    else
                    {
                        Console.Clear();
                        Config.Printer.Print("The Password does not Correspond to the Email given");
                    }
                }
                else if (Keyvalue.Key == ConsoleKey.NumPad5 || Keyvalue.Key == ConsoleKey.D5)
                {
                    Console.Clear();
                    //Exits the program from 
                    break;
                }

            }
        }
    }
}
