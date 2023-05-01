using Kalvad_API_Test.Models;
using System.Diagnostics.Metrics;

namespace Kalvad_API_Test.Interfaces
{
    public interface IAddressRepository
    {
        Address? GetAddressById(int id);
        bool CreateAddress(Address address);
        bool DeleteAddress(Address address);
    }
}
