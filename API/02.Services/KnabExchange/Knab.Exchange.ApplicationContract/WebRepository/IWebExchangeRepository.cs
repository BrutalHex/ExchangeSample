using Knab.Exchange.ApplicationContract.DTO;
using Knab.Exchange.Domain.Currency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knab.Exchange.ApplicationContract.WebRepository
{
   public interface IWebExchangeRepository
    {
        Task<ConvertCurrencyResult> GetRate(string baseName);
    }
}
