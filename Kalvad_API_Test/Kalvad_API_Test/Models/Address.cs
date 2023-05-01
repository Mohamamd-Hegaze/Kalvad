namespace Kalvad_API_Test.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string TypeOfAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AddressLine { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
