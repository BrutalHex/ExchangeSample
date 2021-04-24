using Exchange.IntegrationTest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Exchange.IntegrationTest.Grpc
{
    public class ExchangeConvertorServiceTest : BaseIntegrationTest
    {
        public ExchangeConvertorServiceTest(
        TestWebApplicationFactory<Knab.Exchange.Endpoint.Startup> factory) : base(factory)
        {

        }


        [Fact]
        public async Task Get_exchange_valid_rate()
        {
            var transferClient = new Knab.Exchange.Endpoint.Grpc.ExchangeConvertor.ExchangeConvertorClient(GrpcChannel);
            var respons = await transferClient.GetAsync(new Knab.Exchange.Endpoint.Grpc.ConvertRequest { Crypto="BTC"});

            Assert.True(respons.Rates != null && respons.Rates[0].Value > -1);
        }
        [Fact]
        public async Task Get_exchange_invalid_rate()
        {
            var transferClient = new Knab.Exchange.Endpoint.Grpc.ExchangeConvertor.ExchangeConvertorClient(GrpcChannel);
            var respons = await transferClient.GetAsync(new Knab.Exchange.Endpoint.Grpc.ConvertRequest { Crypto = "v_898" });

            Assert.True(respons.Rates != null && respons.Rates[0].Value ==0);
        }

    }
}
