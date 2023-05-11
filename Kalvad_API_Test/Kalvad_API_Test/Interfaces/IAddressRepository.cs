using Kalvad_API_Test.Models;
using System.Diagnostics.Metrics;

namespace Kalvad_API_Test.Interfaces
{
    public interface IAddressRepository
    {
        Address? GetAddressById(string id);
        bool CreateAddress(Address address);
        bool DeleteAddress(Address address);
    }
}
