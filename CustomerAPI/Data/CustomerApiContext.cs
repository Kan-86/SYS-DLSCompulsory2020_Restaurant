using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace CustomerAPI.Data
{
    public class CustomerApiContext : DbContext
    {
        public CustomerApiContext(DbContextOptions<CustomerApiContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Orders { get; set; }
    }
}
