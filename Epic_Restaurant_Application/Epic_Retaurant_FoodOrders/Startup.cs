using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epic_Retaurant_Food_Menus.Data;
using Epic_Retaurant_Food_Menus.HiddenModels;
using Epic_Retaurant_Food_Menus.Infastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Epic_Retaurant_Food_Menus
{
    public class Startup
    {
        string cloudAMQPConnectionString =
  "host=kangaroo.rmq.cloudamqp.com;virtualHost=tpyrvtpo;username=tpyrvtpo;password=8neWlMBPVyuuxZuSCRtIMhjjz4IxGvoD";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // In-memory database:
            services.AddDbContext<FoodMenusAPIContext>(opt => opt.UseInMemoryDatabase("FoodDb"));

            // Register repositories for dependency injection
            services.AddScoped<IRepository<FoodMenu>, FoodMenusReposittory>();

            // Register database initializer for dependency injection
            services.AddTransient<IDBinitializer, DBInitializer>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Initialize the database
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetService<FoodMenusAPIContext>();
                var dbInitializer = services.GetService<IDBinitializer>();
                dbInitializer.Initialize(dbContext);
            }
            // Create a message listener in a separate thread.
            Task.Factory.StartNew(() =>
                new MessageListener(app.ApplicationServices, cloudAMQPConnectionString).Start());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
