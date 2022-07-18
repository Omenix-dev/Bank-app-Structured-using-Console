using BankingApp.UI.Interaction;
using BankingApp.Core.Contructs.Lower;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;


namespace BankingApp
{
    
    internal class Program
    {
        // contains Private field that force the console to open in FUll windows
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            //Console.ReadLine();
            //System.Console.WriteLine("alsjdbhkas");
            //Created the banking Object; from the Bank Entity Class
            // creating the bank system with a null amount of customer Container
            // Creating a Bank with a Starting Capital of 0.0 Niara
            Bank BankingSystem = new Bank("dAEMON Bank",new List<Customers>(),new SecurityProtocol(),0.0M);

            //================== > ========================
            //welcome page section: interface to introduce
            //the customer to the bank Activities
            Welcome.Show(BankingSystem);

        }
    }
}
