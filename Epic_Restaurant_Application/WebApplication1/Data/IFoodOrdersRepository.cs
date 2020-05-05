

using Epic_Restaurant_Food_Orders.HiddenModels;
using System.Collections.Generic;

namespace Epic_Restaurant_Food_Orders.Data
{
    public interface IFoodOrdersRepository : IRepository<SharedFoodOrder>
    {
        IEnumerable<SharedFoodOrder> GetByFoodId (int customerId);

    }
}
