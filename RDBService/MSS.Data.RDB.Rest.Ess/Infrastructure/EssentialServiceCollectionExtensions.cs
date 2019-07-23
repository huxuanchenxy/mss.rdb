using Microsoft.Extensions.DependencyInjection;
using MSS.Data.RDB.Rest.Ess.V1.Business;
using System;

namespace MSS.Data.RDB.Rest.Ess.Infrastructure
{
    public static class EssentialServiceCollectionExtensions
    {
        public static IServiceCollection AddEssentialService(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<IEalarmService, EalarmService>();
            services.AddTransient<IElogService, ElogService>();
            return services;
        }
    }
}
