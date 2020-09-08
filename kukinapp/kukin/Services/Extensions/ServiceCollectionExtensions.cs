using AutoMapper;
using kukin.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kukin.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddKukinServices(this IServiceCollection services) {
            services.AddKukinAutomapper();
            services.AddTransient<IRecipeService, RecipeService>();

            return services;
        }

        /// <summary>
        /// Adds automapper service
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <returns></returns>
        public static IServiceCollection AddKukinAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            return services;
        }
    }
}
