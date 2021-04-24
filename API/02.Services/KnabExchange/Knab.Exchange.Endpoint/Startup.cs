using Knab.Exchange.Application.WebRepository;
using Knab.Exchange.ApplicationContract.WebRepository;
using Knab.Exchange.Endpoint.Configs;
using Knab.Exchange.Endpoint.Grpc.Map;
using Knab.Exchange.Endpoint.Grpc.services;
using Knab.Framework.Core.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Knab.Exchange.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

      
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
            services.AddSetting(Configuration);
            services.AddHttpClient<IWebExchangeRepository, WebExchangeRepository>();

           
            services.AddControllers();
            services.AddAutoMapper(typeof(ExchangeConvertorProfile));
            services.AddGrpc();
        }

  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<CorsMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<ExchangeConvertorService>();
            });
        }
    }
}
