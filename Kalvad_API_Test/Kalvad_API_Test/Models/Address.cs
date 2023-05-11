namespace Kalvad_API_Test.Models
{
    public class Address
    {
        public string Id { get; set; }
        public string TypeOfAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AddressLine { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
