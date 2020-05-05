using Epic_Restaurant_Application.HiddenModels;
using Epic_Restaurant_Food_Orders.HiddenModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Restaurant_Food_Orders.Data
{
    public class FoodOrdersReposittory : IFoodOrdersRepository
    {
        FoodOrdersAPIContext db;

        public FoodOrdersReposittory(FoodOrdersAPIContext context)
        {
            db = context;
        }

        public FoodOrder Add(SharedFoodOrder entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(SharedFoodOrder entity)
        {
            throw new NotImplementedException();
        }

        public FoodOrder Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SharedFoodOrder> GetAll()
        {
            return db.FoodOrders.ToList();
        }

        public IEnumerable<SharedFoodOrder> GetByFoodId(int customerId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
