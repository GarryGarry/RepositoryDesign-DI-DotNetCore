using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Context;
using MyProject.Respository;

namespace MyProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<BloggingContext>(options => options.UseSqlServer(connection));

            services.AddDbContext<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            // follwing like wont work as it requires typeOf respository (T should of type customer or other entities)
            //services.AddScoped<IRepository, Repository>();

            //services.AddSingleton<IRepository, Repository>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver= new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();

            //app.UseMvc(routes =>
            //{
            //    // You can add all the routes you need here

            //    // And the default route :
            //    routes.MapRoute(
            //         name: "default_route",
            //         template: "{controller}/{action}/{id?}",
            //         defaults: new { controller = "Home", action = "Index" }
            //    );
            //});
        }
    }
}
