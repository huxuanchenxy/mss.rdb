using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MSS.Common.Consul;
using rdbMicroservice.Repository;
using rdbMicroservice.Service;
using Serilog;
using Serilog.Events;

namespace rdbMicroservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                //.WriteTo.Console()
                .WriteTo.File("RDBLogs/Proxy.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("init main");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConsulService(Configuration);
            services.AddDbContext<EssDbContext>(d => d.UseMySQL(Configuration.GetConnectionString("Default")));
            services.AddSingleton<IRdbService, RdbService>();
            services.AddSingleton<IProduicerFactoryService, KafkaProduicerFactoryService>();       
            services.AddSingleton<ISubscribePointDictionary, SubscribePointDictionary>();
            services.AddSingleton<LiteDbRepository>();
            services.AddSingleton<IBackgroundQueue, BackgroundQueue>();
            services.AddHostedService<QueuedHostedService>();
            services.AddHostedService<EventHostedService>();
            services.AddHostedService<MainHostedService>();

            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime, IOptions<ConsulServiceEntity> consulService)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.RegisterConsul(lifetime, consulService);
            app.UseMvc();
        }
    }
}
