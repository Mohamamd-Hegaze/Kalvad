using AutoMapper;
using Kalvad_API_Test.Dto;
using Kalvad_API_Test.DTO;
using Kalvad_API_Test.Interfaces;
using Kalvad_API_Test.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kalvad_API_Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICustomerRepository _csustomerRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, ICustomerRepository csustomerRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _csustomerRepository = csustomerRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        // Create an address for this customer
        public IActionResult CreateAddress(string customerId, [FromBody] AddressDto addressCreate)
        {
            if (addressCreate == null)
                return BadRequest(ModelState);

            // check the customer is exists.
            var customer = _csustomerRepository.GetCustomerById(customerId);

            if (customer == null)
            {
                ModelState.AddModelError("", "Customer is not exists");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // var addressMap = _mapper.Map<Address>(addressCreate);
            var addressMap = addressCreate.GetAddress(customerId);

            if (!_addressRepository.CreateAddress(addressMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return StatusCode(201, "Successfully created");
        }

        [HttpDelete("{customerId}/address/{addressId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        // Delete the address of the customer
        public IActionResult DeleteAddress(string customerId, string addressId)
        {
            // check the customer is exists.
            var customer = _csustomerRepository.GetCustomerById(customerId);

            if (customer == null)
            {
                ModelState.AddModelError("", "Customer is not exists");
                return StatusCode(404, ModelState);
            }

            var addressToDelete = _addressRepository.GetAddressById(addressId);

            if(addressToDelete != null)
            {
                if (!_addressRepository.DeleteAddress(addressToDelete))
                {
                    ModelState.AddModelError("", "Something went wrong deleting address");
                    return StatusCode(500, ModelState);
                }
                return Ok("Deleted");
            }
            // The Address is not exists.
            ModelState.AddModelError("", "Address is not exists");
            return StatusCode(404, ModelState);
        }
    }
}
