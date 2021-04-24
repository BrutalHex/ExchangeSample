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

        [Fact]
        public void Check_Invalid_Enum_Code()
        {
            Assert.Throws<InvalidOperationException>(() => Enumeration.FromValue<Fiat>(1000));

        }


        [Theory]
        [InlineData(1,"USD")]
        [InlineData(2, "EUR")]
        public void Check_Valid_Enum(int code,string name)
        {
           var output= Enumeration.FromValue<Fiat>(code);
            Assert.True(output.Name == name);
        }



    }
}
