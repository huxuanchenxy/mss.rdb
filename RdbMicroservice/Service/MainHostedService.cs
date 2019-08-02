using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using rdbMicroservice.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rdbMicroservice.Service
{
    internal class MainHostedService : IHostedService
    {
        //private readonly ILogger _logger;

        public MainHostedService(IServiceProvider services
            //ILogger<MainHostedService> logger
            )
        {
            Services = services;
            //_logger = logger;
        }

        public IServiceProvider Services { get; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Information(
                "Service Hosted Service is starting.");

            StartWork();
            return Task.CompletedTask;
        }

        private void StartWork()
        {
            Log.Information(
                "Service Hosted Service is working.");
            Task.Run(() => {
                using (var scope = Services.CreateScope())
                {
                    var liteDb = (LiteDbRepository)scope.ServiceProvider.
                        GetRequiredService<LiteDbRepository>();
                    var subcribePointService = (SubscribePointDictionary)scope.ServiceProvider.
                        GetRequiredService<ISubscribePointDictionary>();
                    var rdbService = (RdbService)scope.ServiceProvider.
                        GetRequiredService<IRdbService>();
                    rdbService.Init();
                    rdbService.StartReconnect();

                    var plist = liteDb.GetPoint();
                    var tlist = liteDb.GetTable();

                    foreach (var p in plist)
                    {
                        if (!string.IsNullOrEmpty(p.PID))
                        {
                            var point = rdbService.GetPoint(p.PID);
                            if (point != null)
                            {
                                subcribePointService.Add(point);
                            }
                        }

                    }

                    foreach (var t in tlist)
                    {
                        if (!string.IsNullOrEmpty(t.Name))
                        {
                            var points = rdbService.GetTablePoints(t.Name);
                            foreach (var point in points)
                            {
                                if (point != null)
                                {
                                    subcribePointService.Add(point);
                                }

                            }
                        }
                    }
                    subcribePointService.SetAll();

                }
            });
        
        }
        private void StopWork()
        {
            Log.Information(
                "Service Hosted Service is stop working.");

            using (var scope = Services.CreateScope())
            {
                var rdbService =
                   (RdbService)scope.ServiceProvider
                        .GetRequiredService<IRdbService>();
                rdbService.StopReconnect();
                rdbService.UnInit();

            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information(
                " Service Hosted Service is stopping.");

            return Task.CompletedTask;
        }
    }
}
