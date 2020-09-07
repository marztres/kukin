using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace kukin.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configure Kukin middlewares
        /// </summary>
        /// <param name="app"> applicationbuilder service</param>
        /// <param name="serviceProvider"> serviceProvider service</param>
        /// <param name="env"> Enviroment Service </param>
        /// <returns></returns>
        public static IApplicationBuilder ConfigureKukinApp(this IApplicationBuilder app, IServiceProvider serviceProvider, IWebHostEnvironment env) {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            serviceProvider.MigrateAndSeedData();
            app.UseRouting();
            app.UseKukinCors();
            app.UseKukinSwagger();
            app.UseKukinRoutes();

            return app;
        }

        /// <summary>
        /// Configure kukin Routes
        /// </summary>
        /// <param name="app"> applicationbuilder service</param>
        /// <returns></returns>
        public static IApplicationBuilder UseKukinRoutes(this IApplicationBuilder app ) {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "Api/{controller}/{action=Index}/{id?}"
                    );
            });

            return app;
        }

        /// <summary>
        /// Adds Swagger middleware: Configure Kukin Api
        /// </summary>
        /// <param name="app"> applicationbuilder service</param>
        /// <returns></returns>
        public static IApplicationBuilder UseKukinSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(config => {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Kukin API V1");
                config.RoutePrefix = string.Empty;
            });

            return app;
        }

        /// <summary>
        /// Adds Cors Middleware with kukin policy
        /// </summary>
        /// <param name="app"> applicationbuilder service </param>
        /// <returns></returns>
        public static IApplicationBuilder UseKukinCors(this IApplicationBuilder app)
        {
            app.UseCors("KukinCorsPolicy");

            return app;
        }
    }
}
