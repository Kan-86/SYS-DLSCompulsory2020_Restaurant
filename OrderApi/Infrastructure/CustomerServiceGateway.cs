using RestSharp;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Infrastructure
{
    public class CustomerServiceGateway : IServiceGateway<Customer>
    {
        Uri customerServiceBaseUrl;

        public CustomerServiceGateway( Uri urlBase)
        {
            customerServiceBaseUrl = urlBase;
        }

        public Customer Get(int id)
        {
            RestClient c = new RestClient();
            c.BaseUrl = customerServiceBaseUrl;

            var request = new RestRequest(id.ToString(), Method.GET);
            var response = c.Execute<Customer>(request);
            var orderedProduct = response.Data;
            return orderedProduct;
        }
    }
}
