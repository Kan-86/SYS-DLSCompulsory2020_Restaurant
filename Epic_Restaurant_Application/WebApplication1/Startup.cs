
using Epic_Restaurant_Food_Orders.Data;
using Epic_Restaurant_Food_Orders.HiddenModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Epic_Restaurant_Food_Orders
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
            // In-memory database:
            services.AddDbContext<FoodOrdersAPIContext>(opt => opt.UseInMemoryDatabase("FoodDb"));

            // Register repositories for dependency injection
            services.AddScoped<IRepository<FoodOrder>, FoodOrdersReposittory>();

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
                var dbContext = services.GetService<FoodOrdersAPIContext>();
                var dbInitializer = services.GetService<IDBinitializer>();
                dbInitializer.Initialize(dbContext);
            }

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
