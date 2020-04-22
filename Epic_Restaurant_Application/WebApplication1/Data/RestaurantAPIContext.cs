using Epic_Restaurant_Application.HiddenModels;
using Microsoft.EntityFrameworkCore;

namespace Epic_Restaurant_Application.Data
{
    public class RestaurantAPIContext : DbContext
    {
        public RestaurantAPIContext(DbContextOptions<RestaurantAPIContext> options)
            : base(options)
        {

        }

        public DbSet<FoodMenu> FoodMenus { get; set; }
    }
}
