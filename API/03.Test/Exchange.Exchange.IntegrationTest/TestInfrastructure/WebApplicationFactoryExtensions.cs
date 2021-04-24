using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;

namespace Exchange.IntegrationTest.Infrastructure
{
    public static class WebApplicationFactoryExtensions
    {
        public static HttpClient CreateClientForGrpc<TEntryPoint>(this WebApplicationFactory<TEntryPoint> webApplicationFactory) where TEntryPoint : class
        {
            return webApplicationFactory.CreateDefaultClient(new DelegatingHandler[]
            {
                new OverrideResponseHttpVersionHandler(HttpVersion.Version20)
            });
        }
    }

}
