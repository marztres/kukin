using Microsoft.AspNetCore.Builder;

namespace kukin.Extensions
{
    public static class ApplicationBuilderExtensions
    {
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

        public static IApplicationBuilder UseKukinSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(config => {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Kukin API V1");
                config.RoutePrefix = string.Empty;
            });

            return app;
        }

        public static IApplicationBuilder UseKukinCors(this IApplicationBuilder app)
        {
            app.UseCors("KukinCorsPolicy");

            return app;
        }
    }
}
