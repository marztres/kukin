using kukin.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace kukin.Repositories.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddKukinRepositories(this IServiceCollection services) {
            services.AddTransient<IRecipeRepository, RecipeRepository>();

            return services;
        }

    }
}
