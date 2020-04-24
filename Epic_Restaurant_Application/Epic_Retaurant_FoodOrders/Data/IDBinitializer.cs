using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Restaurant_Application.Data
{
    public interface IDBinitializer
    {
        void Initialize(FoodMenusAPIContext context);
    }
}
