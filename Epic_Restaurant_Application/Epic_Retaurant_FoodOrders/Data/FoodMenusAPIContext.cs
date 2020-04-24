
using Epic_Retaurant_Food_Menus.HiddenModels;
using Microsoft.EntityFrameworkCore;

namespace Epic_Retaurant_Food_Menus.Data
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
