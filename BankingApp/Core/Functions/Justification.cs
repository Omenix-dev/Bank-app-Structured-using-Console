
namespace BankingApp.Core.Functions
{
    public class Justification
    {
        public static string Center(string Text, int i)
        {
            if (Text == null)
            {
                return Text;
            }
            int right = i - Text.Length;
            int left = right / 2 + Text.Length;
            Text = Text.PadLeft(left, ' ').PadRight(i, ' ');
            return Text;
        }
    }
}

