using Kalvad_API_Test.Models;

namespace Kalvad_API_Test.Dto
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Customer GetCustomer()
        {
            return new Customer()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Email = Email
            };
        }
    }
}
