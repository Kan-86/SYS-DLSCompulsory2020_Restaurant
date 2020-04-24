using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Retaurant_Food_Menus.HiddenModels
{
    public class FoodOrderLines
    {
        public int id { get; set; }
        public int FoodOrderId { get; set; }
        public int FoodMenuId { get; set; }
        public int Quantity { get; set; }
    }
}
