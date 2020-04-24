using Epic_Restaurant_Application.HiddenModels;
using Microsoft.EntityFrameworkCore;

namespace Epic_Restaurant_Application.Data
{
    public class FoodOrdersAPIContext : DbContext
    {
        public FoodOrdersAPIContext(DbContextOptions<FoodOrdersAPIContext> options)
            : base(options)
        {

        }

        public DbSet<FoodMenu> FoodMenus { get; set; }
    }
}
