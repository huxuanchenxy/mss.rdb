using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using rdbMicroservice.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rdbMicroservice.Service
{
    public class EventHostedService : IHostedService, IDisposable
    {
        //private readonly ILogger _logger;
        private CancellationTokenSource source;
        private EssDbContext _context;
        private IProducer<Null, string> _producer;
        private long tag = -1;
        public IServiceProvider Services { get; }
        public EventHostedService(IServiceProvider services, IProduicerFactoryService produicerFactoryService
            //ILogger<EventHostedService> logger
            )
        {
            Services = services;
            //_logger = logger;

            _producer = produicerFactoryService.GetNewProducer();
            source = new CancellationTokenSource();

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Information("Timed Background Service is starting.");
            DoWork();
            return Task.CompletedTask;

        }

        private void DoWork()
        {
            Task.Factory.StartNew(() =>
                {

                    while (!source.IsCancellationRequested)
                    {
                        using (var scope = Services.CreateScope())
                        {
                            _context = scope.ServiceProvider.GetRequiredService<EssDbContext>();
                            try
                            {
                                if (tag == -1)
                                {
                                    tag = _context.Events.LongCount();
                                }
                                else
                                {
                                    var current = _context.Events.LongCount();
                                    var num = _context.Events.LongCount() - tag;
                                    if (num == 0)
                                        continue;
                                    var events = _context.Events.FromSql("SELECT * FROM e_log LIMIT {0},{1}", tag, num).AsNoTracking().ToList();
                                    tag = current;
                                    foreach (var e in events)
                                    {
                                        _producer.ProduceAsync("event", new Message<Null, string> { Value = JsonConvert.SerializeObject(e) });
                                    }
                                    _producer.Flush();
                                }
                            }
                            catch (MySqlException ex)
                            {
                                Log.Error(ex.ToString());

                            }

                        }

                        Thread.Sleep(1000);
                    }


                }, TaskCreationOptions.LongRunning);

        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information("Timed Background Service is stopping.");
            source.Cancel();
            return Task.CompletedTask;
        }

        public void Dispose()
        {

        }
    }
}
