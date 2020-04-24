using Epic_Restaurant_Application.HiddenModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Restaurant_Application.Data
{
    interface IFoodOrdersRepository : IRepository<FoodMenu>
    {
        IEnumerable<FoodMenu> GetByFoodId (int customerId);

    }
}
