using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using gasl.Mvc;
using gasl.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using gasl.Web.Infrastructure.Data;

namespace gasl.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcWithFeatureRouting();

            services.AddDbContext<LinkContext>(options =>
                    options.UseInMemoryDatabase());

            services.AddScoped<LinkRepository>();

            services.AddTransient<SeedData>();
        }

        public async void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            SeedData seedData)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(ConfigureRoutes);

            await seedData.InitializeAsync();
        }

        private static void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                name: "default",
                template: "{controller=home}/{action=index}/{id?}");
        }
    }
}
