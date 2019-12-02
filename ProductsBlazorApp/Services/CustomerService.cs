using ProductsBlazorApp.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProductsBlazorApp.Services
{
    public class CustomerService
    {
        // Instance of the db context
        private readonly ProductDbContext db;

        // Constructor using dependency injection
        public CustomerService(ProductDbContext context)
        {
            db = context;
        }

        public List<Customer> GetCustomers()
        {
            return db.Customer.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return db.Customer.SingleOrDefault(c => c.CustomerId == id);
        }

        public bool AddCustomer(Customer customer)
        {
            if (customer != null)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCustomer(int id)
        {
            var customer = db.Customer.Find(id);
            if (customer != null)
            {
                db.Customer.Remove(customer);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateCustomer(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
