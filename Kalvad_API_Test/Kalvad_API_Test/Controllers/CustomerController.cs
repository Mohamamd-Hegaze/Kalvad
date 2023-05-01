using AutoMapper;
using Kalvad_API_Test.Dto;
using Kalvad_API_Test.Interfaces;
using Kalvad_API_Test.Models;
using Kalvad_API_Test.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace Kalvad_API_Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _csustomerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository csustomerRepository, IMapper mapper)
        {
            _csustomerRepository = csustomerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        // Get all customers
        public IActionResult GetCustomers()
        {
            var customers = _csustomerRepository.GetCustomers();
            // var customers = _mapper.Map<List<CustomerDto>>(_csustomerRepository.GetCustomers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customers);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        // Get customer with the id defined
        public IActionResult GetCustomerById(int Id)
        {

            var customers = _csustomerRepository.GetCustomerById(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customers);
        }

        [HttpGet("phone/{prefix}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        [ProducesResponseType(400)]
        // Get all customers starting with the following prefix phone number
        public IActionResult GetCustomersByPhonePrefix(string prefix)
        {
            var customers = _csustomerRepository.GetCustomersByPhonePrefix(prefix);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customers);
        }

        [HttpGet("city/{name}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        [ProducesResponseType(400)]
        // Get all customers from this city
        public IActionResult GetCustomersByCity(string name)
        {
            var customers = _csustomerRepository.GetCustomersByCity(name);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customers);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        // Create a customer
        public IActionResult CreateCustomer([FromBody] CustomerDto customerCreate)
        {
            if (customerCreate == null)
                return BadRequest(ModelState);

            // just for test if customer's FirstName is exists.
            var customer = _csustomerRepository.GetCustomers()
                .Where(c => c.FirstName.Trim().ToUpper() == customerCreate.FirstName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (customer != null)
            {
                ModelState.AddModelError("", "Customer already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerMap = _mapper.Map<Customer>(customerCreate);

            if (!_csustomerRepository.CreateCustomer(customerMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
