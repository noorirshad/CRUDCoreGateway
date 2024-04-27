namespace CRUDCoreGateway.ViewModel
{
    public class ClientViewModel : ClientRequestViewModel
    {
        public Guid ClientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class ClientRequestViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
