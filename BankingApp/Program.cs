using BankingApp.UI.Interaction;
using BankingApp.Core.Contructs.Lower;
using System.Collections.Generic;
using BankingApp.Core;
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
            DIContainer Config = new DIContainer();// creation of a DIContainer

            // forces the console widow to a full screen
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            //Created the banking Object; from the Bank Entity Class
            // creating the bank system with a null amount of customer Container
            Config.Banking("dAEMON Bank",new List<Customers>(),new SecurityProtocol());
            

            //================== > ========================
            //welcome page section: interface to introduce
            //the customer to the bank Activities
            Welcome.Show(Config);

        }
    }
}
