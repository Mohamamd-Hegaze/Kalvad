using AutoMapper;
using Kalvad_API_Test.Data;
using Kalvad_API_Test.Interfaces;
using Kalvad_API_Test.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Kalvad_API_Test.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ICollection<Customer> GetCustomers()
        {
            return _context.Customers.Include(c => c.Addresses).ToList();
        }
        public Customer? GetCustomerById(int id)
        {
            return _context.Customers.Where(c => c.Id == id).Include(c => c.Addresses).FirstOrDefault();
        }
        public ICollection<Customer> GetCustomersByCity(string city)
        {
            return _context.Customers.Where(c => c.Addresses.Any(x => x.City == city)).Include(c => c.Addresses).ToList();
        }

        public ICollection<Customer> GetCustomersByPhonePrefix(string prefix)
        {
            return _context.Customers.Where(c => c.PhoneNumber.StartsWith(prefix))
                .Include(c => c.Addresses).ToList();
        }
        public bool CreateCustomer(Customer customer)
        {
            _context.Add(customer);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
