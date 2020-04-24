
using Epic_Retaurant_Food_Menus.HiddenModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Retaurant_Food_Menus.Data
{
    interface IFoodMenusRepository : IRepository<FoodMenu>
    {
        IEnumerable<FoodMenu> GetByFoodId (int customerId);

    }
}
