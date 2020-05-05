using Epic_Restaurant_Food_Orders.HiddenModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Restaurant_Food_Orders.Infastructure
{
    public class MessagePublisher : IMessagePublisher
    {
        private string cloudAMQPConnectionString;

        public MessagePublisher(string cloudAMQPConnectionString)
        {
            this.cloudAMQPConnectionString = cloudAMQPConnectionString;
        }

        public bool FoodExists(int FoodId)
        {
            throw new NotImplementedException();
        }

        public void PublishOrderStatusChangedMessage(int? customerId, IList<SharedFoodOrderLines> orderLines, string topic)
        {
            throw new NotImplementedException();
        }
    }
}
