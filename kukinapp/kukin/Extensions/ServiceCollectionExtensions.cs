using AutoMapper;
using kukin.Data;
using kukin.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace kukin.Extensions
{
    /// <summary>
    /// Class for configure kukin services
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Kukin Services
        /// </summary>
        /// <param name="services"> Service Collection  </param>
        /// <param name="configuration"> Configuration Service</param>
        /// <returns></returns>
        public static IServiceCollection AddKukinDependencies(this IServiceCollection services, IConfiguration configuration) {
            services.AddKukinCors();
            services.AddKukinControllers();
            services.AddKukinDbContext(configuration);
            services.AddKukinSwagger();
            services.AddKukinTelemetry();
            
            return services;
        }

        /// <summary>
        /// Adds kukin Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddKukinSwagger(this IServiceCollection services) {
            services.AddSwaggerGen(config => {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Kukin api",
                    Version = "v1",
                    Description = "REST APIs "
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        /// <summary>
        /// Adds Kukin Cors Policy
        /// </summary>
        /// <param name="services">Service Collection </param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds controllers services
        /// </summary>
        /// <param name="services"> Service Collection</param>
        /// <returns></returns>
        public static IServiceCollection AddKukinControllers(this IServiceCollection services)
        {
            services.AddControllers( options => {
                options.Filters.Add<ApiExceptionFilter>();
            })
                .ConfigureApiBehaviorOptions(config => {
                    config.SuppressMapClientErrors = true;
                })
                .AddNewtonsoftJson();

            return services;
        }

        /// <summary>
        /// Adds Kukin Db Context
        /// </summary>
        /// <param name="services">Service Collection </param>
        /// <param name="configuration">Configuration service </param>
        /// <returns></returns>
        public static IServiceCollection AddKukinDbContext( this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<KukinDbContext>(context => context
                    .UseSqlServer(
                        configuration.GetConnectionString("KukinDatabase"))
                    );
            
            return services;
        }

        /// <summary>
        /// Adds Azure Insights Service
        /// </summary>
        /// <param name="services"> Service Collection</param>
        /// <returns>Service Collection</returns>
        public static IServiceCollection AddKukinTelemetry(this IServiceCollection services) {

            services.AddApplicationInsightsTelemetry();

            return services;
        }       
    }
}
