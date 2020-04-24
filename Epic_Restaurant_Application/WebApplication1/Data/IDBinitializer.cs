using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Restaurant_Food_Orders.Data
{
    public interface IDBinitializer
    {
        void Initialize(FoodOrdersAPIContext context);
    }
}
