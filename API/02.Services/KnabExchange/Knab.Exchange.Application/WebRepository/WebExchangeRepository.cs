
using Knab.Exchange.Application.DTO.Coinmarketcap;
using Knab.Exchange.Application.Settings;
using Knab.Exchange.ApplicationContract.DTO;
using Knab.Exchange.ApplicationContract.WebRepository;
using Knab.Exchange.Domain.Currency;
using Knab.Framework.Core.Domain;
using Knab.Framework.Core.Domain.Communication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Knab.Exchange.Application.WebRepository
{
   public class WebExchangeRepository: BaseHttpRepository, IWebExchangeRepository
    {

        private readonly AppSettings _appSettings;
     
        public WebExchangeRepository(HttpClient httpClient , AppSettings appSettings ) :base(httpClient)
        {
            _appSettings = appSettings;
          
        }

        /// <summary>
        /// get reate of exchange for given currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public async Task<ConvertCurrencyResult> GetRate(string baseName)
        {
            var headers = GetHeaders();
            ConvertCurrencyResult result = new ConvertCurrencyResult();
            result.BaseCurrency = ExtractBaseCurrency(baseName);
            foreach (var fiat in Enumeration.GetAll<Fiat>())
            {
               ( string name,   double? valueOfConvert )=await GetFiats(result.BaseCurrency, headers, fiat);
                result.Rates.Add(name, valueOfConvert);
            }
            return result;
        }

        /// <summary>
        /// validates in case of null
        /// </summary>
        /// <param name="baseCurrency">crypto name</param>
        /// <returns></returns>
        private string ExtractBaseCurrency(string baseCurrency)
        {
            if (string.IsNullOrEmpty(baseCurrency))
            {
                baseCurrency = Crypto.BTC.Name;
                return baseCurrency;
            }
            return baseCurrency.Trim().Replace(" ", "");
        }

        /// <summary>
        /// extracts the conversion rate based on each Fiat
        /// </summary>
        /// <param name="crypto">base of conversion</param>
        /// <param name="headers"></param>
        /// <param name="fiat">target fiat currency</param>
        /// <returns></returns>
        private async Task<(string,double?)> GetFiats(string baseName, Dictionary<string, string> headers,Fiat fiat)
        {
            Dictionary<string, string> queryString = new Dictionary<string, string>();
            queryString.Add("amount", "1"); 
            queryString.Add("symbol", baseName);
            queryString.Add("convert", fiat.Name);
            var getResult =await Get<CoinmarketCapOutput>(_appSettings.API.PriceConversionUrl, headers, queryString);
            if(getResult.Data==null)
            {
                return (fiat.Name, null);
            }

            BaseCoinmarketCapFiat receivedValueOfFiat = (BaseCoinmarketCapFiat)getResult.Data.Quote.GetType().GetProperty(fiat.Name).GetValue(getResult.Data.Quote);
            return (fiat.Name, receivedValueOfFiat.Price);
        }





        /// <summary>
        /// rthe headers required by the service
        /// </summary>
        /// <returns>
        /// a dictionary containing
        /// </returns>
        private Dictionary<string,string> GetHeaders()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("X-CMC_PRO_API_KEY", _appSettings.API.AccessKey);
            return result;
        }


    }
}
