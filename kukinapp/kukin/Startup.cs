using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace kukin
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "KukinCorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins(
                            "https://kukin-api.azurewebsites.net/",
                            "https://kukinstorage.z19.web.core.windows.net/",
                            "http://localhost:5000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddControllers()
                    .ConfigureApiBehaviorOptions(config => {
                        config.SuppressMapClientErrors = true;
                    });
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI( config => { 
                config.SwaggerEndpoint("/swagger/v1/swagger.json","Kukin API V1");
                config.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
