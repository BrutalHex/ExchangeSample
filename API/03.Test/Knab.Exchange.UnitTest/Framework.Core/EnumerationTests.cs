using Knab.Exchange.Domain.Currency;
using Knab.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Knab.Exchange.UnitTest.Framework.Core
{
   public  class EnumerationTests
    {


        [Theory]
        [InlineData(1, "USD")]
        [InlineData(2, "EUR")]
        public void Check_Valid_Enum(int code, string name)
        {
            var output = Enumeration.FromValue<Fiat>(code);
            Assert.True(output.Name == name);
        }


    
      

        [Fact]
        public static void Pars_of_enum()
        {
            var item = Enumeration.FromDisplayName<Fiat>(Fiat.AUD.Name);

            Assert.True(item.Equals(Fiat.AUD));
        }


        [Fact]
        public static void check_the_enumeration_of_enum()
        {
            var enums = Enumeration.GetAll<Fiat>();
            Assert.True(enums.Count() > 0);
        }

        [Fact]
        public static void check_equality_of_enums()
        {
            var code = Fiat.AUD.Id;
            var newEnum = new Fiat(code, "AUD");
            Assert.True(Fiat.AUD.Equals(newEnum));
        }

        [Fact]
        public static void check_not_equality_of_enums()
        {
            var code = Fiat.AUD.Id;
            var newEnum = new Fiat(10000, "AUD");
            Assert.False(Fiat.AUD.Equals(newEnum));
        }


        [Fact]
        public static void check_compare_of_enums()
        {
            var code = Fiat.AUD.Id;
            var newEnum = new Fiat(code, "AUD");
            Assert.True(Fiat.AUD.Equals(newEnum));
        }

        [Fact]
        public static void check_not_compare_of_enums()
        {
            var code = Fiat.AUD.Id;
            var newEnum = new Fiat(10000, "AUD");
            Assert.False(Fiat.AUD.Equals(newEnum));
        }


        [Fact]
        public void Check_Invalid_Enum_Code()
        {
            Assert.Throws<InvalidOperationException>(() => Enumeration.FromValue<Fiat>(1000));

        }





    }
}
