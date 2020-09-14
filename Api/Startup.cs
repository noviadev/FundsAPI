using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FundsApi.BusinessLogic.Common.Repository;
using FundsApi.BusinessLogic.Common.Services;
using FundsApi.BusinessLogic.Common.Services.Transformers;
using FundsApi.Core.Repositories;
using FundsApi.Core.Services;
using FundsApi.Core.Services.Transformers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Audit.Core.Configuration.Setup()
                .UseFileLogProvider(_ => _
                    .Directory(@"C:\Logs"));

            services.AddMvc();
            services.AddTransient<IFundByMarketCodeGetter, FundByMarketCodeGetterService>();
            services.AddTransient<IFundDetailsEntityLoader, FundDetailsEntityLoaderService>();
            services.AddTransient<IFundDetailsToFundDetailsEntityTransformer, FundDetailsToFundDetailsEntityTransformer>();
            services.AddTransient<IFundDetailsRepository, FundDetailsRepository>();
            services.AddTransient<IFundAllGetter, FundAllGetterService>();
            services.AddTransient<IFundsByFundManagerGetter, FundsByFundManagerGetterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
