using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Retaurant_Food_Menus.Data
{
    public interface IDBinitializer
    {
        void Initialize(FoodMenusAPIContext context);
    }
}
