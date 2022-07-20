using System.Collections.Generic;
using System.Text;

namespace BankingApp.Core.Functions.Interface
{
    public interface IPrinter
    {
        void printTable(List<string[]> TableData, List<string> header_values);
        void printBar(List<string> header_values, StringBuilder TableValue, string brick);
        void printDetails(string[] values, List<string> header_Values, StringBuilder TableValue);
        void Print(string Messg, bool val = false);
    }
}
