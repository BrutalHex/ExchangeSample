using Exchange.IntegrationTest.Infrastructure;
using Knab.Exchange.ApplicationContract.DTO;
using System.Threading.Tasks;
using Xunit;

namespace Exchange.IntegrationTest
{
    public class ExchangeRateControllerTest : BaseIntegrationTest
    {
        public ExchangeRateControllerTest(
        TestWebApplicationFactory<Knab.Exchange.Endpoint.Startup> factory) : base(factory)
        {

        }


        [Theory(DisplayName ="test crypto coin")]
        [InlineData("BTC")]
        [InlineData("ETH")]
        public async Task Test_Http_valid_Get(string code)
        {
           var response= await HttpClient.GetAsync($"http://localhost:5001/api/ExchangeRate/get/{code}");
            var responseData = await response.Content.ReadAsStringAsync();
             var data=  Newtonsoft.Json.JsonConvert.DeserializeObject<ConvertCurrencyResult>(responseData);
            Assert.True(data.Rates != null && data.Rates["USD"].HasValue && data.Rates["USD"].Value > 0);
        }

        [Fact(DisplayName = "test crypto for invalid code")]
        public async Task Test_Http_inlid_code_Get()
        {
            var response = await HttpClient.GetAsync($"http://localhost:5001/api/ExchangeRate/get/c_uiu7");

            var responseData = await response.Content.ReadAsStringAsync();

            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ConvertCurrencyResult>(responseData);
            Assert.False(data.Rates["USD"].HasValue );
        }


    }
}
