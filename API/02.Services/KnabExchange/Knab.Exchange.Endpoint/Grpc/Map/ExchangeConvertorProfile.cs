using AutoMapper;
using Knab.Exchange.ApplicationContract.DTO;
using Knab.Exchange.Domain.Currency;
using Knab.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knab.Exchange.Endpoint.Grpc.Map
{
    public class ExchangeConvertorProfile : AutoMapper.Profile
    {
        public ExchangeConvertorProfile()
        {
            CreateMap<ConvertRequest, Crypto>().ConstructUsing(item => string.IsNullOrEmpty(item.Crypto) ? Crypto.BTC:    new Crypto(0,item.Crypto));



            CreateMap<KeyValuePair<string, double?>, KeyPairDouble>().ConvertUsing(a => new KeyPairDouble { Key = a.Key, Value = a.Value.GetValueOrDefault() });
 
            CreateMap<ConvertCurrencyResult, ConvertResponse>();
        }
    }
}
