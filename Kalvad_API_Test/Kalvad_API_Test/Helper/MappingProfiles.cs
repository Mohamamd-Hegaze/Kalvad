using AutoMapper;
using Kalvad_API_Test.Dto;
using Kalvad_API_Test.DTO;
using Kalvad_API_Test.Models;
using System.Diagnostics.Metrics;

namespace Kalvad_API_Test.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
        }
    }
}
