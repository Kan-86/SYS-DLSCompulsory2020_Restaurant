
using Epic_Retaurant_Food_Menus.HiddenModels;
using System.Collections.Generic;
using System.Linq;

namespace Epic_Retaurant_Food_Menus.Data
{
    public class DBInitializer : IDBinitializer
    {
        // This method will create and seed the database.
        public void Initialize(FoodMenusAPIContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Products
            if (context.FoodMenus.Any())
            {
                return;   // DB has been seeded
            }

            List<FoodMenu> burger = new List<FoodMenu>
            {
                new FoodMenu { 
                    FoodType = "Burger",
                    FoodName = "Jalapeno Burger"
                    }
            };
            List<FoodMenu> fish = new List<FoodMenu>
            {
                new FoodMenu {
                    FoodType = "fish",
                    FoodName = "Freshly baked banana Cod"
                    }
            };
            List<FoodMenu> soup = new List<FoodMenu>
            {
                new FoodMenu {
                    FoodType = "Soup",
                    FoodName = "Tomato Soup"
                    }
            };
            List<FoodMenu> desert = new List<FoodMenu>
            {
                new FoodMenu {
                    FoodType = "Desert",
                    FoodName = "Flaming Dragon Chilli Chocklate Cake"
                    }
            };


            context.FoodMenus.AddRange(burger);
            context.FoodMenus.AddRange(fish);
            context.FoodMenus.AddRange(soup);
            context.FoodMenus.AddRange(desert);
            context.SaveChanges();
        }
    }
}
