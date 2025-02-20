using Data.Entities;

namespace Business.Models;

public class ListUser
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public UserCustomer Customer { get; set; } = null!;
    public UserRole Role { get; set; } = null!;
}
