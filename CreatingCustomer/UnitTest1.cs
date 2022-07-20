using System;
using BankingApp.Core.Functions;
using Xunit;

namespace CreatingCustomer
{
    public class UnitTest1
    {
        [Fact]
        public void nameSanitation()
        {
            var name = "s1avuiyr";

            //bool given = Validation.ValidateName(name);

            //Assert.True(given);
            
        }
        [Fact]
        public void passwordValidations()
        {
            var pass1 = "$%&a";// should expected a fasle value
            var pass2 = "2222222222222";// should expected a fasle value
            var pass3 = "shaytt%$112";// should expected a true value
            var given = Validation.ValidatePassword(pass3);
            foreach (var item in given)
            {
                //Assert.True(item.Value);
            }

        }
        [Fact]
        public void EmailValidations()
        {
            var email1 = "omeni.com";// should expected a fasle value
            var email2 = "savuiue@.com";// should expected a fasle value
            var email3 = "saviour@gmail";// should expected a fasle value
            var email4 = "omenigph@gmail.com";// should expected a true value
            var given = Validation.ValidateEmail(email4);
            //Assert.True(given);
        }
        [Fact]
        public void AccountNumberGenerator()
        {
            int expected = 10;
            int actual = AccountGenerator.Generate().Length;
            Assert.True(expected==actual);
        }

    }
}
