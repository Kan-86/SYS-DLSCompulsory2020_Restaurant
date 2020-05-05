using Epic_Restaurant_Food_Orders.HiddenModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModels
{
    public class FoodOrderStatusChangedMessage
    {
        public int? CustomerId { get; set; }
        public IList<SharedFoodOrderLines> OrderLines { get; set; }
    }
}
