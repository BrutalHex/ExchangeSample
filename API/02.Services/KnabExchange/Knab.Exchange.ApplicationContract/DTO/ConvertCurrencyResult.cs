using System;
using System.Collections.Generic;
using System.Text;

namespace Knab.Exchange.ApplicationContract.DTO
{
    public class ConvertCurrencyResult
    {
        public string BaseCurrency { get; set; }
        public Dictionary<string, double?> Rates { get; set; } = new Dictionary<string, double?>();

    }
}
