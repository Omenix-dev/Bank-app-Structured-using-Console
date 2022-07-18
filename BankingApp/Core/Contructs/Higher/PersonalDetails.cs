using BankingApp.Core.Contructs.Higher.Constants;

namespace BankingApp.Core.Contructs.Higher
{
    public class PersonalDetails
    {

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private int _Age;
        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }

        private IdType _PersonalIdentification;
        protected IdType PersonalIdentification
        {
            get { return _PersonalIdentification; }
            set { _PersonalIdentification = value; }
        }

        private string _IdNo;
        protected string IdNo
        {
            get { return _IdNo; }
            set { _IdNo = value; }
        }

        private string _Occupation;
        protected string Occupation
        {
            get { return _Occupation; }
            set { _Occupation = value; }
        }

        private SexType _Sex;
        public SexType Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        private string _BVN;
        protected string BVN
        {
            get { return _BVN; }
            set { _BVN = value; }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public PersonalDetails(string fullname, int age, SexType sex, IdType id,
                         string bvn, string IdNO, string occupation, string email)
        {
            this.Name = fullname;
            this.Age = age;
            this.PersonalIdentification = id;
            this.IdNo = IdNO;
            this.Sex = sex;
            this.Occupation = occupation;
            this.Email = email;
            this.BVN = bvn;
        }
    }
}
