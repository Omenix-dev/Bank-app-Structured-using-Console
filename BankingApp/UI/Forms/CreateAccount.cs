﻿using BankingApp.Core.Functions;
using BankingApp.Core.Contructs.Lower;
using System;

namespace BankingApp.UI.Forms
{
    public class CreateAccount
    {
        public static void Form(Bank BankingSystem)
        {
            while (true) 
            { 
                
                Printer.Print("Below are options of our banking System service" +
                    " account, press the number representing the account services you prefer", true);
                Console.WriteLine("1.) Create a Savings Account with a minimum of #1000.00K deposit");
                Console.WriteLine("2.) Create a Current Accout with a minimum of #0.00K deposit");
                Console.WriteLine("3.) Exit banking Account creation");

                // this is the section where integer are a been used to segregate the kind of banking system
                int AccountType = -1;
                var keyvalue = Console.ReadKey();
                if (keyvalue.Key == ConsoleKey.D1 || keyvalue.Key == ConsoleKey.NumPad1)
                    AccountType = 0;
                else if (keyvalue.Key == ConsoleKey.D2 || keyvalue.Key == ConsoleKey.NumPad2)
                    AccountType = 1;
                else if (keyvalue.Key == ConsoleKey.D3 || keyvalue.Key == ConsoleKey.NumPad3)
                    break;

                if (AccountType >= 0)
                {
                    Console.Write("\nDeposit money to open account: #");
                    
                    decimal amount;
                    while (!Decimal.TryParse(Console.ReadLine(), out amount))
                    {
                        Printer.Print("Enter a real number in the value");
                    }
                    bool IsCreated = BankingSystem.CreateAccount(AccountType, amount, BankingSystem.Protocol);

                    if (IsCreated)
                    {
                        Console.Clear();
                        PrintCustomer.AccountDetails(BankingSystem.Protocol.SESSION);
                        //true
                        Printer.Print("\nthe account the Account has been successfull created",true);

                    }
                    else
                    {
                        // false
                        Console.Clear();
                        Printer.Print("\nthe Account creating failed becos of the limit" +
                        " of money deposited does not match your account service choices");
                    }
                }
            }
        }
    }
}
