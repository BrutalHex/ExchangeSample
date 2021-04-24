using Exchange.IntegrationTest.Infrastructure;
using Knab.Exchange.Application.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Exchange.IntegrationTest.Other
{
    public class AppSettingsTest : BaseIntegrationTest
    {
        public AppSettingsTest(
        TestWebApplicationFactory<Knab.Exchange.Endpoint.Startup> factory) : base(factory)
        {

        }
        [Fact]
        public void Check_application_settings()
        {
            var settings =(AppSettings) Factory.ServiceProvider.GetService(typeof(AppSettings));

            Assert.True(settings != null);
            Assert.True(settings.API != null && settings.API.PriceConversionUrl.Length>0);
            
        }

    }
}
