using Epic_Restaurant_Application.HiddenModels;
using Epic_Restaurant_Food_Orders.HiddenModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Restaurant_Food_Orders.Data
{
    public class DBInitializer : IDBinitializer
    {
        // This method will create and seed the database.
        public void Initialize(FoodOrdersAPIContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Products
            if (context.FoodOrders.Any())
            {
                return;   // DB has been seeded
            }

            List<FoodOrder> burger = new List<FoodOrder>
            {
                new FoodOrder 
                {
                    Date = DateTime.Now,
                     FoodOrderLines = new List<FoodOrderLines>
                     {
                        new FoodOrderLines 
                        { 
                            FoodMenuId = 1, Quantity = 2, FoodOrderId = 1 
                        }
                     }
                }
            };
            List<FoodOrder> fish = new List<FoodOrder>
            {
                new FoodOrder
                {
                    Date = DateTime.Now,
                     FoodOrderLines = new List<FoodOrderLines>
                     {
                        new FoodOrderLines
                        {
                            FoodMenuId = 1, Quantity = 2, FoodOrderId = 1
                        }
                     }
                }
            };
            List<FoodOrder> soup = new List<FoodOrder>
            {
                new FoodOrder
                {
                    Date = DateTime.Now,
                     FoodOrderLines = new List<FoodOrderLines>
                     {
                        new FoodOrderLines
                        {
                            FoodMenuId = 1, Quantity = 2, FoodOrderId = 1
                        }
                     }
                }
            };
            List<FoodOrder> desert = new List<FoodOrder>
            {
                new FoodOrder
                {
                    Date = DateTime.Now,
                     FoodOrderLines = new List<FoodOrderLines>
                     {
                        new FoodOrderLines
                        {
                            FoodMenuId = 1, Quantity = 2, FoodOrderId = 1
                        }
                     }
                }
            };


            context.FoodOrders.AddRange(burger);
            context.FoodOrders.AddRange(fish);
            context.FoodOrders.AddRange(soup);
            context.FoodOrders.AddRange(desert);
            context.SaveChanges();
        }
    }
}
