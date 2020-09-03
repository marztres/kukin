using kukin.Data;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace kukin.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceProvider MigrateAndSeedData(this IServiceProvider serviceProvider) {
            KukinDbContext kukinDbContext = serviceProvider.GetService<KukinDbContext>();

            kukinDbContext.Database.EnsureCreated();

            return serviceProvider;
        }
    }
}
