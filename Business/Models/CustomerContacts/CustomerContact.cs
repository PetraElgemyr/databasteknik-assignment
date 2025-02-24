using Business.Models.Customers;
using Data.Entities;

namespace Business.Models.CustomerContacts;


public class CustomerContact
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public CustomerWithoutType Customer { get; set; } = null!;

}