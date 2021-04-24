using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knab.Exchange.Domain.Currency
{
    public class Crypto: Currency
    {
        public static Crypto BTC => new Crypto(1,"BTC");

        public Crypto( int id,string name) : base(id, name)
        {
        






        }
    }
}
