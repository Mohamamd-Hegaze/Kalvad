using Kalvad_API_Test.Models;
using System.Diagnostics.Metrics;

namespace Kalvad_API_Test.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
        Customer? GetCustomerById(int id);
        ICollection<Customer> GetCustomersByPhonePrefix(string prefix);
        ICollection<Customer> GetCustomersByCity(string city);
        bool CreateCustomer(Customer customer);
    }
}
