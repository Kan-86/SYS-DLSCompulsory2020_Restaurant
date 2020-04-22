using Epic_Restaurant_Application.HiddenModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Restaurant_Application.Data
{
    public class RestaurantReposittory : IRestaurantRepository
    {
        RestaurantAPIContext db;

        public RestaurantReposittory(RestaurantAPIContext context)
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
