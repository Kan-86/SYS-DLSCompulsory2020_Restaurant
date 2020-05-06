using System.Collections.Generic;
using SharedModels;

namespace CustomerAPI.Data
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetByCustomer(int customerId);
    }
}
