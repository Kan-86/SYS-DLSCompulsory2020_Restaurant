using Epic_Restaurant_Application.HiddenModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Restaurant_Food_Orders.Infastructure
{
    public class FoodMenuGateway
    {
        public class ProductServiceGateway : IServiceGateway<SharedFoodMenu>
        {
            Uri productServiceBaseUrl;

            public ProductServiceGateway(Uri baseUrl)
            {
                productServiceBaseUrl = baseUrl;
            }
            public SharedFoodMenu Get(int id)
            {
                RestClient c = new RestClient();
                c.BaseUrl = productServiceBaseUrl;

                var request = new RestRequest(id.ToString(), Method.GET);
                var response = c.Execute<SharedFoodMenu>(request);
                var orderedProduct = response.Data;
                return orderedProduct;
            }
        }
    }
}
