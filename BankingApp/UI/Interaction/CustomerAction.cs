using System;
using System.Collections.Generic;
using BankingApp.Core.Contructs.Lower;
using BankingApp.Core.Functions;
using BankingApp.UI.Forms;


namespace BankingApp.UI.Interaction
{
    internal class CustomerAction
    {
        public static void Service(Bank BankingSystem)
        {
            while (true)
            {
                Console.WriteLine($"<============================================== {BankingSystem.Protocol.SESSION.PersonalDetails.Name} Welcome to {BankingSystem.BankName} ============================================>");
                Console.WriteLine("\n<======================================Press the Serial number representing the prefered banking services you want to perform=================================>");
                // display banking services
                List<string> headerValues = new List<string> { "S/N", "Banking Services", "Restriction" };
                List<string[]> footerValues = new List<string[]>
                {
                    new string[] {"1","Create Account","All Customers"},
                    new string[] {"2","Deposit Money","Everybody"},
                    new string[] {"3","Withdraw Money","All Customer"},
                    new string[] {"4","Transfer Money","All Customer"},
                    new string[] {"5","print Statement","All Customer"},
                    new string[] {"6","print Account","All Customer"},
                    new string[] {"7","Logout","All Customer"},
                };
                Printer.printTable(footerValues,headerValues);

                var keyvalue = Console.ReadKey();
                if (keyvalue.Key == ConsoleKey.D1 || keyvalue.Key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    CreateAccount.Form(BankingSystem);
                    Console.Clear();
                }
                else if (keyvalue.Key == ConsoleKey.D2 || keyvalue.Key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the amount you wish to deposit");
                    decimal amount = Validation.Amount();

                    Console.WriteLine("Enter Recipient Account Number");
                    string accountNumber = Console.ReadLine();

                    Console.WriteLine("Enter reason for deposit");
                    string desc = Validation.IsRequired<string>(Console.ReadLine());
                    bool value = BankingSystem.Protocol.SESSION.Deposit
                                (BankingSystem, amount, accountNumber, desc);

                    Console.Clear();
                    if (value) Printer.Print("Transaction Successfull", true);
                    else Printer.Print("Transaction UNSuccessfull", false);
                }
                else if (keyvalue.Key == ConsoleKey.D3 || keyvalue.Key == ConsoleKey.NumPad3)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the amount you wish to Withdrawal");
                    decimal amount = Validation.Amount();

                    Console.WriteLine("Enter Recipient Account Number");
                    string accountNumber = Console.ReadLine();

                    Console.WriteLine("Enter reason for deposit");
                    string desc = Validation.IsRequired<string>(Console.ReadLine());
                    bool value = BankingSystem.Protocol.SESSION.WithdrawalRequest
                                (BankingSystem, amount, accountNumber, desc);

                    Console.Clear();
                    if (value) Printer.Print("\nTransaction Successfull", true);
                    else Printer.Print("\nTransaction UNSuccessfull", false);
                }
                else if (keyvalue.Key == ConsoleKey.D4 || keyvalue.Key == ConsoleKey.NumPad4)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the amount you wish to transfer");
                    decimal amount = Validation.Amount();

                    Console.WriteLine("Enter Recipient Account Number");
                    string RecipientNumber = Console.ReadLine();

                    Console.WriteLine("Enter the account Number you wish to transfer with");
                    string SendersNumber = Console.ReadLine();

                    Console.WriteLine("Enter reason for Transaction: ");
                    string desc = Validation.IsRequired<string>(Console.ReadLine());
                    bool value = BankingSystem.Protocol.SESSION.TransferRequest
                                (BankingSystem, amount, SendersNumber, RecipientNumber, desc);

                    Console.Clear();
                    if (value) Printer.Print("Transaction Successfull", true);
                    else Printer.Print("Transaction UNSuccessfull", false);
                }
                else if (keyvalue.Key == ConsoleKey.D5 || keyvalue.Key == ConsoleKey.NumPad5)
                {
                    Console.Clear();
                    Console.WriteLine("To print your account statement fill in this information\n");
                    Console.Write("Fill in the account number you wish to print its statemnt:");
                    string accNo = Validation.IsRequired<string>(Console.ReadLine());
                    BankingSystem.Protocol.SESSION.RequestStatement(BankingSystem, accNo);
                    Console.WriteLine("press enter to exit");
                    Console.ReadLine();
                    Console.Clear() ;   
                }
                else if (keyvalue.Key == ConsoleKey.D6 || keyvalue.Key == ConsoleKey.NumPad6)
                {
                    Console.Clear();
                    // this dumps the SESSION to null thereby logging out the Customer
                    PrintCustomer.AccountDetails(BankingSystem.Protocol.SESSION);
                    Console.WriteLine("Press Enter to Exit");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (keyvalue.Key == ConsoleKey.D7 || keyvalue.Key == ConsoleKey.NumPad7)
                {
                    // this dumps the SESSION to null thereby logging out the Customer
                    BankingSystem.Protocol.SESSION.Logout(BankingSystem);
                    Console.Clear();
                    break;
                }
            }
        }
    }
}
