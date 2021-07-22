using System.Collections.Generic;

namespace Api.Data
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        Customer DeleteCustomerById(int Id);
        Customer DeleteCustomer(Customer customer);
    }
}
