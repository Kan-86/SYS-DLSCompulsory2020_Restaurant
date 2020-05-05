using Epic_Restaurant_Food_Orders.HiddenModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Restaurant_Food_Orders.Infastructure
{
    public interface IMessagePublisher
    {
        bool FoodExists(int FoodId);
        void PublishOrderStatusChangedMessage(int? customerId,
            IList<SharedFoodOrderLines> orderLines, string topic);
    }
}
