using kukin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kukin.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddKukinCors(this IServiceCollection services) {

            services.AddCors(options =>
            {
                options.AddPolicy(name: "KukinCorsPolicy",
                    builder =>
                    {
                        //builder.WithOrigins(                            
                        //    "https://kukinstorage.z19.web.core.windows.net/",
                        //    "http://localhost:4200")
                        //.AllowAnyHeader()
                        //.AllowAnyMethod();

                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            return services;
        }

        public static IServiceCollection AddKukinControllers(this IServiceCollection services)
        {
            services.AddControllers()
                      .ConfigureApiBehaviorOptions(config => {
                          config.SuppressMapClientErrors = true;
                      });

            return services;
        }

        public static IServiceCollection AddKukinDbContext( this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<KukinDbContext>(context => context
                    .UseSqlServer(
                        configuration.GetConnectionString("KukinDatabase"))
                    );
            
            return services;
        }

    }
}
