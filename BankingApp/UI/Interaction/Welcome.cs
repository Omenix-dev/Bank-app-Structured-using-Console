using System;
using System.Collections.Generic;
using BankingApp.Core.Contructs.Lower;
using BankingApp.Core.Functions;
using BankingApp.UI.Forms;

namespace BankingApp.UI.Interaction
{
    public class Welcome
    {
        public static void Show(Bank BankingSystem)
        {
            //ultimate Looper that prevents the loop from ending
            while (true)
            {
                Console.WriteLine($"<==============================================Welcome to {BankingSystem.BankName} ============================================>");

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
                Printer.printTable(footerValues,headerValues);
                
                ConsoleKeyInfo Keyvalue = Console.ReadKey();
                if(Keyvalue.Key == ConsoleKey.NumPad1 || Keyvalue.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    bool Message = Registeration.Forms(BankingSystem);
                    if (Message) 
                    {
                        Console.Clear();
                        Printer.Print("\nYou have Successfully been Registered",true);
                    }
                    else
                    {
                        Console.Clear();
                        Printer.Print("\nthe registration was not successful");
                    }
                    continue;
                }
                else if(Keyvalue.Key == ConsoleKey.NumPad2 || Keyvalue.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Printer.Print("You are not yet Logged in and therefore can not perform a Create Account Action");
                }
                else if (Keyvalue.Key == ConsoleKey.NumPad3 || Keyvalue.Key == ConsoleKey.D3)
                {
                    
                    Console.Clear();
                    Console.WriteLine("Enter the amount you wish to deposit");
                    decimal amount = Validation.Amount();

                    Console.WriteLine("Enter Recipient Account Number");
                    string accountNumber = Console.ReadLine();

                    Console.WriteLine("Enter reason for deposit");
                    string desc = Validation.IsRequired<string>(Console.ReadLine());
                    bool value = BankingSystem.AcceptDeposit(amount, accountNumber,
                                desc,BankingSystem.Protocol,BankingSystem.Customers);

                    Console.Clear();
                    if (value) Printer.Print("Transaction Successfull", true);
                    else Printer.Print("Transaction UNSuccessfull", false);
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
                    bool IsValid = BankingSystem.LoginCustomer(Email,password,BankingSystem.Customers,BankingSystem.Protocol);
                    if (IsValid)
                    {
                        Console.Clear();
                        CustomerAction.Service(BankingSystem);
                    }
                    else
                    {
                        Console.Clear();
                        Printer.Print("The Password does not Correspond to the Email given");
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
