using System.Collections;

namespace BankingApp.Core.Functions.Interface
{
    public interface IUpdateAndPreview
    {
        ArrayList Edit( string IdNO, int IdType, string BVN,
                        string Occupation, int Sex,
                        int Age, string email,
                        string fullname);
    }
}
