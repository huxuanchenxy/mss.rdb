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
        private string tag2 = string.Empty;
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
                                if (string.IsNullOrEmpty(tag2))
                                {
                                    //tag = _context.Events.LongCount();
                                    tag2 = _context.Events.FromSql(" select ETime from e_log order by ETime desc limit 1 ").AsNoTracking().FirstOrDefault().ETime.ToString();
                                }
                                else
                                {
                                    //var current = _context.Events.LongCount();
                                    var current = _context.Events.LongCount();
                                    var num = _context.Events.LongCount() - tag;
                                    if (num == 0)
                                        continue;
                                    //var events = _context.Events.FromSql("SELECT * FROM e_log LIMIT {0},{1}", tag, num).AsNoTracking().ToList();
                                    var events = _context.Events.FromSql(" SELECT a.ETime ,a.ETime_MS ,a.PID ,a.ELevel ,a.Ack ,a.OriginTime ,a.OriginTime_MS ,a.RestoreTime ,a.RestoreTime_MS ,a.AckTime ,a.AckTime_MS ,a.NodeID ,a.User ,a.Src ,a.Type ,a.EQDes ,a.PIDDes ,a.ValueDisplay ,a.Des ,a.StnNo ,a.StnName ,a.SpecialtyNo ,a.EQType ,a.PushGraph from e_log as a inner join ( SELECT ETime, ETime_MS, PID from e_log ORDER BY ETime limit {0},{1} ) as b on a.ETime = b.ETime and a.ETime_MS = b.ETime_MS and a.PID = b.PID ", tag, num).AsNoTracking().ToList();
                                    //tag = current;
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
