using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Exchange.IntegrationTest.Infrastructure
{

    /// <summary>
    /// provides the basic functionality for integration tests
    /// </summary>
    public class BaseIntegrationTest : IClassFixture<TestWebApplicationFactory<Knab.Exchange.Endpoint.Startup>>
    {
        public TestWebApplicationFactory<Knab.Exchange.Endpoint.Startup> Factory { get; private set; }

        private readonly HttpClient _grpHttpClient;
        /// <summary>
        /// HttpClient for communicate with gRPC and Web services
        /// </summary>
        protected HttpClient GrpcHttpClient => _grpHttpClient;

        /// <summary>
        /// the gRPC channel of the project
        /// </summary>
        protected GrpcChannel GrpcChannel { get; private set; }

        public HttpClient HttpClient { get; private set; }

        /// <summary>
        /// provides the basic functionality for integration tests
        /// </summary>
        /// <param name="factory"></param>
        public BaseIntegrationTest(TestWebApplicationFactory<Knab.Exchange.Endpoint.Startup> factory)
        {
            Factory = factory;
            _grpHttpClient = factory.CreateClientForGrpc();
            GrpcChannel = GrpcChannel.ForAddress("https://localhost:5000", new GrpcChannelOptions()
            {
                HttpClient = GrpcHttpClient
            });

            HttpClient = factory.CreateClient();
        }

    }
}
