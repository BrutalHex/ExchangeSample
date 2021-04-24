using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knab.Exchange.Application.Settings
{
    public class AppSettings 
    {
      
        public API API { get; set; }

      
    }

    public class API 
    {
        public string AccessKey { get; set; }
        public string PriceConversionUrl { get; set; }
    }
}
