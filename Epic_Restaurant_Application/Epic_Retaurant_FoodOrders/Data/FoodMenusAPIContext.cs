using Epic_Restaurant_Application.HiddenModels;
using Microsoft.EntityFrameworkCore;

namespace Epic_Restaurant_Application.Data
{
    public class FoodMenusAPIContext : DbContext
    {
        public FoodMenusAPIContext(DbContextOptions<FoodMenusAPIContext> options)
            : base(options)
        {

        }

        public DbSet<FoodMenu> FoodMenus { get; set; }
    }
}
