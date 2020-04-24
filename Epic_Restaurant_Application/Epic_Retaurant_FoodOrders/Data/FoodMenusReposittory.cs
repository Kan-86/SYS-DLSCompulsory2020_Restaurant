
using Epic_Retaurant_Food_Menus.HiddenModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epic_Retaurant_Food_Menus.Data
{
    public class FoodMenusReposittory : IFoodMenusRepository
    {
        FoodMenusAPIContext db;

        public FoodMenusReposittory(FoodMenusAPIContext context)
        {
            db = context;
        }

        public FoodMenu Add(FoodMenu entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(FoodMenu entity)
        {
            throw new NotImplementedException();
        }

        public FoodMenu Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FoodMenu> GetAll()
        {
            return db.FoodMenus.ToList();
        }

        public IEnumerable<FoodMenu> GetByFoodId(int customerId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
