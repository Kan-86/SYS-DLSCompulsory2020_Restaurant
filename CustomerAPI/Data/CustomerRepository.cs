using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SharedModels;
using System;

namespace CustomerAPI.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerApiContext db;

        public CustomerRepository(CustomerApiContext context)
        {
            db = context;
        }

        public Customer Add(Customer entity)
        {
            var newOrder = db.Orders.Add(entity).Entity;
            db.SaveChanges();
            return newOrder;
        }

        public void Edit(Customer entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Customer Get(int id)
        {
            return db.Orders.Include(o => o.Id).FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Orders.ToList();
        }

        public IEnumerable<Customer> GetByCustomer(int customerId)
        {
            var ordersForCustomer = from o in db.Orders
                                    where o.Id == customerId
                                    select o;

            return ordersForCustomer.ToList();
        }

        public void Remove(int id)
        {
            var order = db.Orders.FirstOrDefault(p => p.Id == id);
            db.Orders.Remove(order);
            db.SaveChanges();
        }
    }
}
