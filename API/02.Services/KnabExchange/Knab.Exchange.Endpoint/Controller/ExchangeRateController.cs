using Knab.Exchange.ApplicationContract.DTO;
using Knab.Exchange.ApplicationContract.WebRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Knab.Exchange.Endpoint.Controller
{
    [Route("api/[controller]/[action]/{key?}")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        IWebExchangeRepository _webExchangeRepository;
        public ExchangeRateController(IWebExchangeRepository webExchangeRepository)
        {
            _webExchangeRepository = webExchangeRepository;
        }


        /// <summary>
        /// fetchs exchange rates of given crypto
        /// </summary>
        /// <param name="key">crypto currency code of coinmarketcap</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ConvertCurrencyResult> Get(string key)
        {
            var result =await _webExchangeRepository.GetRate(key);
            return result;
        }

    }
}
