using BankingApp.Core.Functions.Interface;
using System;
using System.Text.RegularExpressions;

namespace BankingApp.Core.Functions
{
    public class Validation : IValidation
    {
        DIContainer Config = new DIContainer();
        public string ValidateName(string name)
        {
            Config.Print();//instantiate the printer property
            name = IsRequired<string>(name);
            while (true)
            {
                if (Char.IsDigit(name[0]))
                {
                    Config.Printer.Print("Please enter a name without the number at the begining");
                    name = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            // this is used to change case of the upper
            char[] nam = name.ToCharArray();
            nam[0] = Char.ToUpper(nam[0]);
            name="";
            for (int i = 0; i < nam.Length; i++) name += nam[i];
            return name.Trim();
            
        }

        public string ValidatePassword(string password)
        {
            Config.Print();//instantiate the printer property
            Regex Digit = new Regex(@"[0-9]+");
            Regex alpha = new Regex(@"[a-zA-Z]+");
            Regex special = new Regex(@"[@#$%^&!]+");
            while (true)
            {
                password = IsRequired<string>(password);
                int len = password.Length;
                if (len > 5 && Digit.IsMatch(password) && alpha.IsMatch(password) && special.IsMatch(password))
                {
                    return password;
                }
                else
                {
                    if (Digit.IsMatch(password))
                         Config.Printer.Print("password must contain a digit", false);
                    if(alpha.IsMatch(password))
                        Config.Printer.Print("password must contain an Alphabet", false);
                    if (special.IsMatch(password))
                        Config.Printer.Print("password must contain a special Character", false);
                    if (len < 5)
                        Config.Printer.Print("password must have more than five character", false);
                   password = Console.ReadLine();
                }
            }
        }

        public string ValidateEmail(string Email)
        {
            Config.Print();//instantiate the printer property
            var exp = new Regex(@"\S+@\S+[.][a-zA-Z]");
            while (true)
            {
                Email = IsRequired<string>(Email);
                if (exp.IsMatch(Email))
                    return Email;
                Config.Printer.Print("Please enter a valid: omeni324@gmail.com");
                Email = Console.ReadLine();
            }
        }
        public T IsRequired<T>(T value)
        {
            Config.Print();//instantiate the printer property
            while (true)
            {
                if(!String.IsNullOrEmpty((string)Convert.ChangeType(value,typeof(string))))
                    return (T)Convert.ChangeType(value, typeof(T));
                Config.Printer.Print("this Field cant be left empty, its required");
                value = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
            }
        }
        public int EnumConverters<T>() where T : System.Enum
        {
            Config.Print();//instantiate the printer property
            int value;
            int i = 1;
            int Len = Enum.GetNames(typeof(T)).Length;
            foreach (var item in Enum.GetNames(typeof(T))) { Console.WriteLine($"{i}: {item}");i++; }
            while (true)
            {
                while (true)
                {
                    if (Int32.TryParse(Console.ReadLine(), out value)) break;
                    Config.Printer.Print("please enter a number");
                }
                if (value >= 1 && value <= Len) break;
                Config.Printer.Print("please enter a number corresponding to that in the dropdown");
            }
            return value;
        }
        public decimal Amount()
        {
            Config.Print();//instantiate the printer property
            decimal value;
            while (true)
            {
                if (Decimal.TryParse(Console.ReadLine(), out value) && value > 0) break;
                Config.Printer.Print("please enter a valid real number");
            }
            return value;
        }
    }
}

