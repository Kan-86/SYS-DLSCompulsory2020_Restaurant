using Epic_Restaurant_Application.HiddenModels;
using Epic_Restaurant_Food_Orders.HiddenModels;
using Microsoft.EntityFrameworkCore;

namespace Epic_Restaurant_Food_Orders.Data
{
    public class FoodOrdersAPIContext : DbContext
    {
        public FoodOrdersAPIContext(DbContextOptions<FoodOrdersAPIContext> options)
            : base(options)
        {

        }

        public DbSet<SharedFoodOrder> FoodOrders { get; set; }
    }
}
