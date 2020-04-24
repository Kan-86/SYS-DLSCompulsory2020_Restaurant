using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Restaurant_Food_Orders.HiddenModels
{
    public class SharedFoodOrder
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? customerId { get; set; }
        public OrderStatus Status { get; set; }
        public IList<SharedFoodOrderLines> FoodOrderLines { get; set; }

        public enum OrderStatus
        {
            cancelled,
            completed,
            shipped,
            paid
        }
    }
}
