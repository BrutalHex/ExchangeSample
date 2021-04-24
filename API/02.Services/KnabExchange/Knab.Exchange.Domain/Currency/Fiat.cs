using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knab.Exchange.Domain.Currency
{
    
    public class Fiat : Currency
    {
        public static Fiat USD => new Fiat(1,"USD");
        public static Fiat EUR => new Fiat(2,"EUR");
        public static Fiat GBP => new Fiat(3,"GBP");
        public static Fiat AUD => new Fiat(4,"AUD");
        public static Fiat BRL => new Fiat(5,"BRL");

  
        public Fiat( int id,string name) : base(id, name)
        {

        }
    }
}
