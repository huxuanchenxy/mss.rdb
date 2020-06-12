using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Loader;

namespace rdbMicroservice
{
    public class Program
    {
        //static readonly Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();       
              
            host.Run();
            
            TryLoadAssembly();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseKestrel(options =>
            {
                int port = int.Parse(args[0]);
                options.Listen(IPAddress.Any, port);
                //options.Listen(IPAddress.Any, 443, listenOptions =>
                //{
                //    listenOptions.UseHttps("server.pfx", "password");
                //});
            })
                .UseStartup<Startup>()
                .UseContentRoot(Path.GetDirectoryName(typeof(Program).Assembly.Location))
                  .ConfigureAppConfiguration((hostingContext, config) =>
            {
                //config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile(
                    "config.json", optional: true, reloadOnChange: true);
            }).UseSerilog((context, configuration) => configuration
                .Enrich.FromLogContext()
                .MinimumLevel.Warning()
                .WriteTo.Console()
                .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.RollingFile(@"RDBLogs/Information-{Date}.log"))
                .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning).WriteTo.RollingFile(@"RDBLogs/Warning-{Date}.log"))
                .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug).WriteTo.RollingFile(@"RDBLogs/Debug-{Date}.log"))
                .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error).WriteTo.RollingFile(@"RDBLogs/Error-{Date}.log")),

                preserveStaticLogger: true)

        // .ConfigureLogging(logging =>
        //{
        //    logging.ClearProviders();
        //    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
        //})
        //.UseNLog()
            ;  // NLog: setup NLog for Dependency injection

        private static void TryLoadAssembly()
        {
            Assembly entry = Assembly.GetEntryAssembly();

            string dir = Path.GetDirectoryName(entry.Location);
            string entryName = entry.GetName().Name;

            foreach (string dll in Directory.GetFiles(dir, "*.dll"))
            {
                if (entryName.Equals(Path.GetFileNameWithoutExtension(dll))) { continue; }

                try
                {
                    AssemblyLoadContext.Default.LoadFromAssemblyPath(dll);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }
        }
    }
}
