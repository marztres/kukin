using kukin.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.ComponentModel;

namespace kukin.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceProvider MigrateAndSeedData(this IServiceProvider serviceProvider) {
            KukinDbContext kukinDbContext = serviceProvider.GetService<KukinDbContext>();

            kukinDbContext.Database.Migrate();
            SeedKukinDataAsync(serviceProvider).Wait();

            return serviceProvider;
        }

        public async static Task SeedKukinDataAsync(IServiceProvider serviceProvider) {
            //Delete this await Task.FromResult("Peding to add seed data."); when there is something to seed
            await Task.FromResult("Peding to add seed data.");
        }
    }
}
