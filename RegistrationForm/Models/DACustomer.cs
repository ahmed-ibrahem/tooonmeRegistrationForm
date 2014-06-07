using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationForm.Models
{
    public class DACustomer
    {
        public IEnumerable<CustomerViewModel> GetAllCustomers()
        {
            using (dbContext ctx = new dbContext())
            {
                IEnumerable<CustomerViewModel> customers = ctx.Customers.ToList();
                return customers;
            }

        }

        public CustomerViewModel GetCustomerDetails(int customerID)
        {
            using (dbContext ctx = new dbContext())
            {
                CustomerViewModel customer = ctx.Customers.Find(customerID);
                return customer;
            }
        }

        public bool CreateNewCustomer(CustomerViewModel customer)
        {
            int count = 0;
            using (dbContext ctx = new dbContext())
            {
                ctx.Customers.Add(customer);
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public bool EditCustomer(CustomerViewModel customer)
        {
            int count = 0;
            using (dbContext ctx = new dbContext())
            {
                ctx.Entry(customer).State= System.Data.Entity.EntityState.Modified;
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public bool RemoveCustomer(int customerID)
        {
            int count = 0;
            using (dbContext ctx = new dbContext())
            {
                CustomerViewModel customer = ctx.Customers.Find(customerID);
                if (customer == null)
                    return false;

                ctx.Customers.Remove(customer);
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }
    }
}