using Microsoft.Extensions.DependencyInjection;
using MSS.Data.RDB.Rest.His.V1.Business;
using System;

namespace MSS.Data.RDB.Rest.His.Infrastructure
{
    public static class EssentialServiceCollectionExtensions
    {
        public static IServiceCollection AddEssentialService(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<IHfrqService, HfrqService>();
            return services;
        }
    }
}
