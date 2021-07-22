using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext context;

        public CustomerRepository(CustomerContext context)
        {
            this.context = context;
        }

        public List<Customer> GetAllCustomers()
        {
            return context.Customer.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return context.Customer.FirstOrDefault(c => c.Id == id);
        }

        public Customer AddCustomer(Customer customer)
        {
            if (customer != null)
            {
                context.Customer.Add(customer);
                context.SaveChanges();
            }
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var customerExists = context.Customer.Find(customer.Id);
            if (customerExists != null)
            {
                customerExists.Name = customer.Name;
                customerExists.Location = customer.Location;
                customerExists.Email = customer.Email;
                customerExists.Phone = customer.Phone;

                context.SaveChanges();
            }
            else
            {
                throw new ApplicationException("Customer not found");
            }
            return customerExists;
        }

        public Customer DeleteCustomer(Customer customer)
        {
            if (customer != null)
            {
                var exists = context.Customer.Find(customer.Id);
                if (exists != null)
                {
                    context.Customer.Remove(exists);
                    context.SaveChanges();
                }
                else
                {
                    throw new ApplicationException("Customer not found");
                }

            }
            return customer;
        }

        public Customer DeleteCustomerById(int id)
        {
            var existCustomer = context.Customer.Find(id);
            if (existCustomer != null)
            {
                context.Customer.Remove(existCustomer);
                context.SaveChanges();
            }
            else
            {
                throw new ApplicationException("Customer not found");
            }

            return existCustomer;
        }

    }
}
