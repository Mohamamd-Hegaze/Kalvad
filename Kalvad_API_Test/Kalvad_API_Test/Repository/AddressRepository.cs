using AutoMapper;
using Kalvad_API_Test.Data;
using Kalvad_API_Test.Interfaces;
using Kalvad_API_Test.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Kalvad_API_Test.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AddressRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateAddress(Address address)
        {
            _context.Add(address);
            return Save();
        }

        public bool DeleteAddress(Address address)
        {
            _context.Remove(address);
            return Save();
        }

        public Address? GetAddressById(int id)
        {
            return _context.Addresses.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
