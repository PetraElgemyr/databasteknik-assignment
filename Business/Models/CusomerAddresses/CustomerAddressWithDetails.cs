using Business.Models.CustomerContacts;

namespace Business.Models.CusomerAddresses;

public class CustomerAddressWithDetails
{
    public int Id { get; set; }
    public string StreetName { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public PostalCodeRegistrationForm PostalCode { get; set; } = null!;
    public CustomerAddressCustomerContact CustomerContact { get; set; } = null!;
}


