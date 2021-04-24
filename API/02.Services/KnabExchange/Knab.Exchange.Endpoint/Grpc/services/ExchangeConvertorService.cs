using AutoMapper;
using Grpc.Core;
using Knab.Exchange.ApplicationContract.WebRepository;
using Knab.Exchange.Domain.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knab.Exchange.Endpoint.Grpc.services
{

    /// <summary>
    /// exchange service 
    /// </summary>
    /// <remarks>
    /// grpc ui command:
    /// grpcui -proto exchangeConvertor.proto -import-path "C:\projects\Test\Knab\ExchangeSample\API\02.Services\KnabExchange\Knab.Exchange.Endpoint\Grpc\Proto" -plaintext localhost:5000
    /// </remarks>
    public class ExchangeConvertorService : ExchangeConvertor.ExchangeConvertorBase
    {
        private readonly IWebExchangeRepository _webExchangeRepository;
        private readonly IMapper _mapper;
        public ExchangeConvertorService(IWebExchangeRepository webExchangeRepository, IMapper mapper)
        {
            _webExchangeRepository = webExchangeRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// returns the conversion rate for given crypto
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async override Task<ConvertResponse> Get(ConvertRequest request, ServerCallContext context)
        {
            var mappedRequest = _mapper.Map<Crypto>(request);
            var convrtResult = await _webExchangeRepository.GetRate(mappedRequest.Name);
            var result = _mapper.Map<ConvertResponse>(convrtResult);
            return result;
        }
    }
}
