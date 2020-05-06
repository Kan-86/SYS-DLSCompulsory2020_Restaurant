using System;
using System.Collections.Generic;
using System.Linq;
using SharedModels;

namespace CustomerAPI.Data
{
    public class DbInitializer : IDbInitializer
    {
        // This method will create and seed the database.
        public void Initialize(CustomerApiContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Orders
            if (context.Orders.Any())
            {
                return;   // DB has been seeded
            }
            List<Customer> orders = new List<Customer>
            {
                new Customer {
                    Name = "Kris",
                    Credits = 222
                }
            };
            List<Customer> orders1 = new List<Customer>
            {
                new Customer {
                    Name = "Alex the Smallex",
                    Credits = 22
                }
            };

            List<Customer> orders2 = new List<Customer>
            {
                new Customer {
                    Name = "Sam the Ham",
                    Credits = 9999
                }
            };

            context.Orders.AddRange(orders);
            context.Orders.AddRange(orders1);
            context.Orders.AddRange(orders2);
            context.SaveChanges();
        }
    }
}
