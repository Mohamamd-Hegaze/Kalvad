using Kalvad_API_Test.Models;

namespace Kalvad_API_Test.DTO
{
    public class AddressDto
    {
        public string TypeOfAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AddressLine { get; set; }
        public Address GetAddress(string CustomerId)
        {
            return new Address()
            {
                Id = Guid.NewGuid().ToString(),
                TypeOfAddress = TypeOfAddress,
                City = City,
                Country = Country,
                AddressLine = AddressLine,
                CustomerId = CustomerId
            };
        }
    }
}
