using Kalvad_API_Test.Models;
using System.ComponentModel.DataAnnotations;

namespace Kalvad_API_Test.Dto
{
    public class CustomerDto
    {
        [Required(ErrorMessage = "FirstName Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "PhoneNumber Required")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "EmailAddress Required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
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
