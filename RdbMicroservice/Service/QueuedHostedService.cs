using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace rdbMicroservice.Service
{

    public class QueuedHostedService : BackgroundService
    {
        //private readonly ILogger _logger;
        private readonly IProducer<Null, string> _producer;
        public IBackgroundQueue messageQueue { get; }

        public QueuedHostedService(IBackgroundQueue messageQueue
            //,
            //ILoggerFactory loggerFactory
            , IProduicerFactoryService produicerFactoryService)
        {
            this.messageQueue = messageQueue;
            //_logger = loggerFactory.CreateLogger<QueuedHostedService>();
            _producer = produicerFactoryService.GetDefaultProducer();
        }

        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            Log.Information("Queued Hosted Service is starting.");
            while (!cancellationToken.IsCancellationRequested)
            {
                var point = await messageQueue.DequeueAsync(cancellationToken);
                if (point == null)
                    continue;
                try
                {
                    double value = -1;
                    double dw = -1;
                    double ddw = -1;
                    double up = -1;
                    double uup = -1;
                    DateTime dateTime = System.DateTime.Now;
                    DateTime updateTime = new DateTime();
                    string ut = null;
                    point.Read("Value", ref value);
                    point.Read("Time", ref dateTime);
                    point.Read("UT", ref ut);
                    point.Read("UP", ref up);
                    point.Read("UUP", ref uup);
                    point.Read("DW", ref dw);
                    point.Read("DDW", ref ddw);
                    point.Read("UpdateTime", ref updateTime);
                    RdbMessage message = new RdbMessage
                    {
                        PID = point.PID,
                        Value = value,
                        time = ConvertDataTimeToLong(dateTime),
                        UT = ut
                    ,
                        DDW = ddw,
                        DW = dw,
                        UP = up,
                        UUP = uup,
                        UpdateTime = updateTime
                    };
                    await _producer.ProduceAsync("data", new Message<Null, string> { Value = JsonConvert.SerializeObject(message) });

                }
                catch (Exception ex)
                {
                    Log.Error(ex,
                       $"Error occurred executing ExecuteAsync.");
                }
            }

            Log.Information("Queued Hosted Service is stopping.");
        }

        public static long ConvertDataTimeToLong(DateTime dt)
        {
            //DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime dtStart = new DateTime(1970, 1, 1);
            TimeSpan toNow = dt.Subtract(dtStart);
            long timeStamp = toNow.Ticks;
            timeStamp = long.Parse(timeStamp.ToString().Substring(0, timeStamp.ToString().Length - 4));
            return timeStamp;
        }

        //public Task StartAsync(CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation("Timed Background Service is starting.");
        //    DoWork(cancellationToken);
        //    return Task.CompletedTask;
        //}
        //private Task DoWork(CancellationToken cancellationToken)
        //{
        //    return Task.Factory.StartNew(() =>
        //    {

        //        while (!cancellationToken.IsCancellationRequested)
        //        {
        //            var point = messageQueue.Dequeue();
        //            if (point == null)
        //                continue;
        //            try
        //            {
        //                double value = -1;
        //                DateTime dateTime = new DateTime();
        //                point.Read("Value", ref value);
        //                point.Read("Time", ref dateTime);
        //                RdbMessage message = new RdbMessage { PID = point.PID, Value = value, Time = dateTime };
        //                _producer.Produce("data", new Message<Null, string> { Value = JsonConvert.SerializeObject(message) });

        //            }
        //            catch (Exception ex)
        //            {
        //                _logger.LogError(ex,
        //                   $"Error occurred executing ExecuteAsync.");
        //            }
        //        }

        //        _logger.LogInformation("Queued Hosted Service is stopping.");

        //    }, TaskCreationOptions.LongRunning);


        //}

        //public Task StopAsync(CancellationToken cancellationToken)
        //{
        //    _producer.Dispose();
        //    return Task.CompletedTask;
        //}
    }
}
